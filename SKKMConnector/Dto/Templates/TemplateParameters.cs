using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Параметры создания или изменения шаблона печати:
/// <para>
/// Name - Уникальное имя шаблона на сервере
/// </para>
/// <para>
/// Type - Тип шаблона. Используйте enum <see cref="PrintTemplateType"/>
/// </para>
/// <para>
/// TemplateItems - Строки шаблона (<see cref="TemplateItem"/> / <see cref="PrintLine"/>)
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("AC99BCEF-46AC-46F0-91A8-043307E0CA30")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class TemplateParameters
{
    /// <summary>
    /// Имя шаблона. Уникальный идентификатор на сервере.
    /// Разрешены символы a-z, A-Z, 0-9, _, -, (, ). Пробелы запрещены.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Тип шаблона. Используйте enum <see cref="PrintTemplateType"/>.
    /// </summary>
    public PrintTemplateType Type { get; set; }

    /// <summary>
    /// Строки шаблона (текст, штрихкод, картинка, разделительная линия).
    /// </summary>
    public List<TemplateItem> TemplateItems { get; set; } = [];

    /// <summary>
    /// Добавляет текстовую строку в шаблон — удобный способ для COM-клиентов
    /// (VBA/1С), которым неудобно создавать TemplateItem/PrintLine вручную.
    /// </summary>
    public void AddTextLine(string text, string textRight = "", int width = 0, int scale = 100)
    {
        var line = new PrintLine
        {
            Type = PrintLineType.Text,
            Line = text,
            LineRight = textRight,
            Width = width,
            Scale = scale,
        };
        TemplateItems.Add(new TemplateItem { PrintLine = line });
    }

    /// <summary>Добавляет разделительную линию в шаблон.</summary>
    public void AddSeparatorLine()
    {
        TemplateItems.Add(new TemplateItem { PrintLine = new PrintLine { Type = PrintLineType.Separator } });
    }

    /// <summary>
    /// Добавляет строку со штрихкодом — удобный способ для COM-клиентов, которым
    /// неудобно создавать TemplateItem/PrintLine/PrintFormBarcode вручную.
    /// </summary>
    public void AddBarcodeLine(string value, BarcodeType type = BarcodeType.CODE128, int height = 100, int barWidth = 2)
    {
        var line = new PrintLine
        {
            Type = PrintLineType.Barcode,
            Barcode = new PrintFormBarcode
            {
                Type = type,
                Value = value,
                Height = height,
                BarWidth = barWidth,
            },
        };
        TemplateItems.Add(new TemplateItem { PrintLine = line });
    }

    /// <summary>
    /// Добавляет строку с изображением (Base64) — удобный способ для COM-клиентов,
    /// которым неудобно создавать TemplateItem/PrintLine/Picture вручную.
    /// </summary>
    public void AddPictureLine(string pictureBase64, int width = 0, int height = 0, PictureAlignment alignment = PictureAlignment.Center)
    {
        var line = new PrintLine
        {
            Type = PrintLineType.Picture,
            Picture = new Picture
            {
                PictureBase64 = pictureBase64,
                Width = width == 0 ? null : width,
                Height = height == 0 ? null : height,
                Alignment = alignment,
            },
        };
        TemplateItems.Add(new TemplateItem { PrintLine = line });
    }

    /// <summary>Очищает строки шаблона.</summary>
    public void ClearTemplateItems() => TemplateItems.Clear();
}