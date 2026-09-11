using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Строка штрихкода в чеке:
/// <para>
/// Type - Тип штрихкода
/// </para>
/// <para>
/// Value - Значение
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("52128D28-6F91-4F13-B057-816EA076E8C0")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class BarcodeLine : Position
{
    /// <summary>
    /// Тип штрихкода
    /// </summary>
    public string Type { get; set; } = "";

    /// <summary>
    /// Значение штрихкода
    /// </summary>
    [JsonPropertyName("Value")]
    public string Barcode { get; set; } = "";

    /// <summary>
    /// Значение штрихкода в Base64
    /// </summary>
    public string? ValueBase64 { get; set; }

    /// <summary>
    /// Выравнивание штрихкода
    /// </summary>
    public string? Alignment { get; set; }
}
