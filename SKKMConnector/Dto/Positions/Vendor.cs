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
}
