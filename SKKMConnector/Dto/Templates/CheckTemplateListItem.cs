using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Элемент списка шаблонов чека.
/// </summary>
[ComVisible(true)]
[Guid("360D9420-650B-4258-AB25-1EDBA7E217F3")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class CheckTemplateListItem
{
    /// <summary>
    /// Имя шаблона чека.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Тип чека шаблона
    /// </summary>
    public CheckType TaskType { get; set; }
}
