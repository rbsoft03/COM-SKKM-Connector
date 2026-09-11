using System.Runtime.InteropServices;
namespace RBSoftSkkm;

/// <summary>
/// Изображение в чеке:
/// <para>
/// Value - Картинка в Base64
/// </para>
/// <para>
/// Alignment - Выравнивание. Используйте enum <see cref="PictureAlignment"/>
/// </para>
/// <para>
/// Width / Height - Размер (при необходимости)
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("4EC083CE-085E-4C00-B79B-1142DFE5109F")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class PictureLine : Position
{
    /// <summary>
    /// Изображение в Base64.
    /// </summary>
    public string Value { get; set; } = "";

    /// <summary>
    /// Выравнивание изображения. Используйте enum <see cref="PictureAlignment"/>.
    /// </summary>
    public PictureAlignment Alignment { get; set; } = PictureAlignment.Center;

    /// <summary>
    /// Ширина изображения.
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// Высота изображения.
    /// </summary>
    public int? Height { get; set; }
}
