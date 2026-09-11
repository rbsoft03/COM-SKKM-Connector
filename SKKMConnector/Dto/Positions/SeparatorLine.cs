using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Разделительная линия в чеке:
/// <para>
/// LineStyle - Стиль. Используйте enum <see cref="LineStyle"/>
/// </para>
/// </summary>
[ComVisible(true)]
[Guid("D7362F89-F251-49DB-813D-901E165A9375")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class SeparatorLine : Position
{
    /// <summary>
    /// Стиль разделительной линии. Используйте enum <see cref="LineStyle"/>.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle LineStyle { get; set; } = LineStyle.Solid;
}
