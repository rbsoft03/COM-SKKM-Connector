using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Элемент истории обработки операции.
/// </summary>
[ComVisible(true)]
[Guid("8FB36346-DD3D-422E-A0A8-C2DF59FE60B7")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class OperationHistoryItem
{
    /// <summary>
    /// Время события.
    /// </summary>
    [JsonPropertyName("Time")]
    public DateTime Time { get; set; }

    /// <summary>
    /// Код состояния.
    /// </summary>
    [JsonPropertyName("State")]
    public int State { get; set; }

    /// <summary>
    /// Описание события.
    /// </summary>
    [JsonPropertyName("Description")]
    public string Description { get; set; } = "";

    /// <summary>
    /// Состояние документа на этом шаге.
    /// </summary>
    [JsonPropertyName("Document")]
    public CheckDocument? Document { get; set; }
}
