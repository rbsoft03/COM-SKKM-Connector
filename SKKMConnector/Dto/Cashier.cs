using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Сведения о кассире (продавце):
/// <para>
/// Name - ФИО кассира
/// </para>
/// <para>
/// Vatin - ИНН кассира (при наличии)
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("06F2F074-C91D-4BCE-9189-A7524F45CBFD")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class Cashier
{
    /// <summary>
    /// Имя кассира.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// ИНН кассира.
    /// </summary>
    public string? Vatin { get; set; }
}