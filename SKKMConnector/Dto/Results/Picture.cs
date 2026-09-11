using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Элемент списка изображений.
/// </summary>
[ComVisible(true)]
[Guid("ACB63427-15DE-4232-AD9E-5EE6BBC9BAC7")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class Picture
{
    /// <summary>
    /// Название изображения.
    /// </summary>
    [JsonPropertyName("PictureName")]
    public string? PictureName { get; set; }

    /// <summary>
    /// Выравнивание изображения.
    /// </summary>
    [JsonPropertyName("Alignment")]
    public PictureAlignment Alignment { get; set; }

    /// <summary>
    /// Изображение в Base64 (строка шаблона печати / печатной формы).
    /// </summary>
    [JsonPropertyName("PictureBase64")]
    public string? PictureBase64 { get; set; }

    /// <summary>
    /// Ширина изображения при печати, в точках.
    /// </summary>
    [JsonPropertyName("Width")]
    public int? Width { get; set; }

    /// <summary>
    /// Высота изображения при печати, в точках.
    /// </summary>
    [JsonPropertyName("Height")]
    public int? Height { get; set; }
}
