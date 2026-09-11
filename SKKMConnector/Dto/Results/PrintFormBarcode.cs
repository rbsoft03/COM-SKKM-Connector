using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Штрихкод в печатной форме.
/// </summary>
[ComVisible(true)]
[Guid("8C668C42-FD51-4D16-99C7-495B092E674B")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class PrintFormBarcode
{
    /// <summary>
    /// Тип штрихкода.
    /// </summary>
    [JsonPropertyName("Type")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public BarcodeType? Type { get; set; }

    /// <summary>
    /// Значение штрихкода.
    /// </summary>
    [JsonPropertyName("Value")]
    public string? Value { get; set; }

    /// <summary>
    /// Изображение штрихкода, закодированное в Base64.
    /// </summary>
    [JsonPropertyName("PictureBase64")]
    public string? PictureBase64 { get; set; }

    /// <summary>
    /// Способ печати текста штрихкода (только для одномерных).
    /// </summary>
    [JsonPropertyName("PrintText")]
    public BarcodePrintText PrintText { get; set; }

    /// <summary>
    /// Высота штрихкода в точках. Допустимые значения: 0..1199.
    /// </summary>
    [JsonPropertyName("Height")]
    public int Height { get; set; }

    /// <summary>
    /// Ширина штриха в точках. Допустимые значения: 0..1199. Рекомендуемое значение — 2.
    /// </summary>
    [JsonPropertyName("BarWidth")]
    public int BarWidth { get; set; }
}
