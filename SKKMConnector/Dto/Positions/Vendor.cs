using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Данные поставщика:
/// <para>
/// Name - Наименование поставщика
/// </para>
/// <para>
/// Phones - Телефон(ы) поставщика
/// </para>
/// <para>
/// Vatin - ИНН поставщика
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("95CB4244-5B3A-468B-B9C5-52A564685773")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class Vendor
{
    /// <summary>
    /// Наименование поставщика.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Телефоны поставщика.
    /// </summary>
    public string[]? Phones { get; set; }

    /// <summary>
    /// ИНН поставщика.
    /// </summary>
    public string? Vatin { get; set; }

    /// <summary>
    /// Добавляет телефон поставщика (можно вызвать несколько раз для нескольких номеров) —
    /// удобный способ для COM-клиентов (1С/VBA), которым нельзя напрямую заполнить string[].
    /// </summary>
    public void AddPhone(string phone)
    {
        var old = Phones ?? Array.Empty<string>();
        var next = new string[old.Length + 1];
        old.CopyTo(next, 0);
        next[old.Length] = phone;
        Phones = next;
    }
}
