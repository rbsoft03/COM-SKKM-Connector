using System.Text;
using System.Text.RegularExpressions;

namespace RBSoftSkkm.Internal;

/// <summary>
/// Разбор, нормализация и восстановление формата кода маркировки (GS1 DataMatrix / КИЗ) —
/// портировано из <c>DeviceNetBase.Utility.CommonOperation</c> (репозиторий сервера ККМ, skkm4),
/// без обращения к серверу. Оставлена только часть, нужная для локального исправления кода
/// (<see cref="SkkmConnector.RepairMarkingLocal"/>).
/// </summary>
internal static class Gs1CodeUtility
{
    private static readonly char Gs = (char)0x1D;

    private static readonly Regex EscapedGsSeparatorRegex = new(
        @"\\(?:u\{0*1[dD]\}|u001[dD]|U0000001[dD]|x\{0*1[dD]\}|x001[dD]|x1[dD])",
        RegexOptions.CultureInvariant | RegexOptions.Compiled);

    /// <summary>
    /// Проверка строки на соответствие Base64.
    /// </summary>
    public static bool IsBase64(string base64String)
    {
        if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
            || base64String.Contains(' ') || base64String.Contains('\t') || base64String.Contains('\r') || base64String.Contains('\n'))
            return false;

        try
        {
            Convert.FromBase64String(base64String);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Раскодирование строки Base64. Бросает исключение, если строка не является корректным Base64.
    /// </summary>
    public static string DecodeFromBase64(string base64)
    {
        var bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// GS1 КМ формата 01+GTIN+21+SN обязан содержать криптохвост (AI 91/92, 93 или 8005).
    /// Для прочих форматов (табак без 01, шубы и т.п.) возвращает true.
    /// </summary>
    public static bool IsMarkingCodeCryptoValid(string code)
    {
        if (string.IsNullOrEmpty(code))
            return false;

        if (code.Length < 18 || !code.StartsWith("01", StringComparison.Ordinal) || code.Substring(16, 2) != "21")
            return true;

        var parts = code.Split(Gs);
        for (var i = 1; i < parts.Length; i++)
        {
            var part = parts[i];
            if (part.StartsWith("91", StringComparison.Ordinal) || part.StartsWith("92", StringComparison.Ordinal)
                || part.StartsWith("93", StringComparison.Ordinal) || part.StartsWith("8005", StringComparison.Ordinal))
                return true;
        }

        if (parts.Length != 1)
            return false;

        var afterSerial = code.Substring(18);
        return afterSerial.Contains("8005") || afterSerial.Contains("91") || afterSerial.Contains("92") || afterSerial.Contains("93");
    }

    /// <summary>
    /// Возвращает код маркировки Base64 с исправленным форматом (см. <see cref="CheckFormatAndRepairGs1M"/>).
    /// </summary>
    public static string RemoveBracketsFromBase64(string base64)
    {
        if (string.IsNullOrWhiteSpace(base64))
            return base64;

        try
        {
            return CheckFormatAndRepairGs1M(base64);
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch
        {
            return base64;
        }
    }

    /// <summary>
    /// Раскодирует строку маркировки из Base64, проверяет на соответствие форматам GS1 DataMatrix,
    /// удаляет подстроки вида "(01)"/"(21)"/"(91)"/"(92)"/"(93)"/"(335)" — 1С иногда отправляет их со скобками —
    /// и вставляет символ-разделитель GS1 (ASCII 29) на нужные позиции, если он отсутствует.
    /// КМ формата GS1 без криптохвоста (AI 91/92/93) запрещены — бросает <see cref="ArgumentException"/>.
    /// Если формат не распознан — возвращает исходную строку без изменений.
    /// </summary>
    public static string CheckFormatAndRepairGs1M(string gs1Base64)
    {
        if (string.IsNullOrWhiteSpace(gs1Base64))
            return gs1Base64;

        var input = gs1Base64;
        if (!TryGetDecodableBase64(ref input))
            return gs1Base64;

        try
        {
            string gs1 = Gs.ToString();
            string fnc1 = char.ConvertFromUtf32(232);
            string zwnbsp = char.ConvertFromUtf32(0xfeff);

            var markingCodeBytes = Convert.FromBase64String(input);
            var productCode = Repair1CUrlSafeMarkingCode(Encoding.UTF8.GetString(markingCodeBytes));
            var replaced = productCode.Replace(zwnbsp, "").Replace(fnc1, "").Replace(" ", "");

            // Очистка от служебных управляющих символов (кроме нужного нам GS1) — могли попасть из-за кривой работы сканера.
            for (var indexer = 1; indexer < 29; indexer++)
            {
                string symbol = char.ConvertFromUtf32(indexer);
                replaced = replaced.Replace(symbol, string.Empty);
            }

            if (replaced.StartsWith("(01)", StringComparison.Ordinal))
            {
                replaced = "01" + replaced.Substring(4);

                const string substring = "(21)";
                int indexOfSubstring = replaced.IndexOf(substring, StringComparison.Ordinal);
                if (indexOfSubstring == 16)
                    replaced = replaced.Substring(0, 16) + "21" + replaced.Substring(20);
            }

            replaced = replaced.Replace("(91)", "91");
            replaced = replaced.Replace("(92)", "92");
            replaced = replaced.Replace("(93)", "93");
            replaced = replaced.Replace("(335)", "335");

            var buffer = replaced;

            if (replaced.StartsWith("01", StringComparison.Ordinal) && replaced.Length >= 18 && replaced.Substring(16, 2) == "21")
            {
                replaced = replaced.Replace(gs1, "");

                // Длины и позиции ниже соответствуют форматам GS1 DataMatrix для разных товарных групп
                // (табак, шины, лекарства, БАД, молочная продукция, пиво и т.д.) — вставляем разделитель GS1
                // перед служебными тегами AI, если сканер/1С его потерял.
                if (replaced.Length >= 41 && replaced.Substring(25, 4) == "8005" && replaced.Substring(35, 2) == "93")
                {
                    replaced = replaced.Insert(25, gs1);
                    replaced = replaced.Insert(36, gs1);
                    if (replaced.Length > 43)
                        replaced = replaced.Insert(43, gs1);
                }
                else if (replaced.Length == 31 && replaced.Substring(25, 2) == "93")
                {
                    replaced = replaced.Insert(25, gs1);
                }
                else if (replaced.Length == 83 && replaced.Substring(31, 2) == "91" && replaced.Substring(37, 2) == "92")
                {
                    replaced = replaced.Insert(31, gs1);
                    replaced = replaced.Insert(38, gs1);
                }
                else if (replaced.Length == 127 && replaced.Substring(31, 2) == "91" && replaced.Substring(37, 2) == "92")
                {
                    replaced = replaced.Insert(31, gs1);
                    replaced = replaced.Insert(38, gs1);
                }
                else if (replaced.Length == 90 && replaced.Substring(38, 2) == "91" && replaced.Substring(44, 2) == "92")
                {
                    replaced = replaced.Insert(38, gs1);
                    replaced = replaced.Insert(45, gs1);
                }
                else if (replaced.Length == 30 && replaced.Substring(24, 2) == "93")
                {
                    replaced = replaced.Insert(24, gs1);
                }
                else if (replaced.Length == 40 && replaced.Substring(24, 2) == "93" && replaced.Substring(30, 4) == "3103")
                {
                    replaced = replaced.Insert(24, gs1);
                    replaced = replaced.Insert(31, gs1);
                }
                else if (replaced.Length == 37 && replaced.Substring(31, 2) == "93")
                {
                    replaced = replaced.Insert(31, gs1);
                }
                else if (replaced.Length == 41 && replaced.Substring(31, 3) == "335" && replaced.Substring(25, 2) == "93")
                {
                    replaced = replaced.Insert(31, gs1);
                    replaced = replaced.Insert(25, gs1);
                }
                else if (replaced.Length == 76 && replaced.Substring(24, 2) == "91" && replaced.Substring(30, 2) == "92")
                {
                    replaced = replaced.Insert(24, gs1);
                    replaced = replaced.Insert(31, gs1);
                }
                else
                {
                    // неизвестный формат — восстанавливаем как было
                    replaced = buffer;
                }
            }

            if (!IsMarkingCodeCryptoValid(replaced))
                throw new ArgumentException("Код маркировки без криптохвоста запрещён.");

            var strAscii = Encoding.UTF8.GetBytes(replaced);
            return Convert.ToBase64String(strAscii);
        }
        catch (ArgumentException)
        {
            throw;
        }
        catch
        {
            return gs1Base64;
        }
    }

    /// <summary>
    /// Проверка — Base64 или Base64URL, перевод Base64URL в стандартный Base64. Текстовый КМ не трогаем.
    /// </summary>
    private static bool TryGetDecodableBase64(ref string value)
    {
        if (IsBase64(value))
            return true;

        var normalized = value.Trim().Replace('-', '+').Replace('_', '/');
        var mod = normalized.Length % 4;
        if (mod > 0)
            normalized += new string('=', 4 - mod);

        if (!IsBase64(normalized))
            return false;

        value = normalized;
        return true;
    }

    /// <summary>
    /// Заменяет литеральные escape-последовательности GS (\x1d, \u001d и др.) на символ GS (ASCII 29).
    /// </summary>
    public static string ReplaceEscapedGsSeparators(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        if (text.IndexOf('\\') >= 0)
            text = EscapedGsSeparatorRegex.Replace(text, "\u001d");

        if (text.IndexOf("<GS>", StringComparison.OrdinalIgnoreCase) >= 0)
            text = Regex.Replace(text, "<GS>", "\u001d", RegexOptions.IgnoreCase);

        return text;
    }

    /// <summary>
    /// 1С иногда заменяет '=' на '_' в конце криптохвоста КМ.
    /// </summary>
    private static string Repair1CUrlSafeMarkingCode(string markingCode)
    {
        if (string.IsNullOrEmpty(markingCode))
            return markingCode;

        markingCode = ReplaceEscapedGsSeparators(markingCode);

        if (markingCode[markingCode.Length - 1] != '_')
            return markingCode;

        return markingCode.Substring(0, markingCode.Length - 1) + "=";
    }
}
