using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Шаблон чека, полученный с сервера.
/// </summary>
[ComVisible(true)]
[Guid("4D420F89-545D-4F62-B3C5-CA159AEE56F5")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class CheckTemplate
{
    /// <summary>
    /// Идентификатор шаблона на сервере.
    /// </summary>
    public string Id { get; set; } = "";

    /// <summary>
    /// Имя шаблона чека.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Документ шаблона.
    /// </summary>
    public CheckTemplateDocument? Document { get; set; }
}
