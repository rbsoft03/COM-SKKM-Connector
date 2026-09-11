using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Дополнительный реквизит пользователя чека:
/// <para>
/// Name - Имя реквизита
/// </para>
/// <para>
/// Value - Значение реквизита
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("2A9BEBCD-088F-442F-85A7-DE88E7A2874D")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class UserAttribute
{
    /// <summary>
    /// Имя реквизита.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Значение реквизита.
    /// </summary>
    public string? Value { get; set; }
}
