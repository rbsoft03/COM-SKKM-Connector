using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Сведения о приложении-источнике запроса.
/// </summary>
[ComVisible(true)]
[Guid("5C14D519-C737-4361-A908-327496665AB5")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class SenderInfo
{
    /// <summary>
    /// Название приложения.
    /// </summary>
    [JsonPropertyName("AppName")]
    public string AppName { get; set; } = "";

    /// <summary>
    /// Версия приложения.
    /// </summary>
    [JsonPropertyName("AppVersion")]
    public string AppVersion { get; set; } = "";
}
