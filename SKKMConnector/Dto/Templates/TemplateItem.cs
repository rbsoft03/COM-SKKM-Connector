using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Элемент шаблона печати. Создайте объект и задайте <see cref="PrintLine"/>.
/// </summary>
[ComVisible(true)]
[Guid("49EB91D8-D19A-49A2-8EBC-BE8E50BD3613")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class TemplateItem
{
    /// <summary>
    /// Строка печати: текст, штрихкод, изображение или разделительная линия.
    /// </summary>
    public PrintLine? PrintLine { get; set; }
}
