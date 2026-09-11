using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Токен авторизации пользователя.
/// </summary>
[ComVisible(true)]
[Guid("877C398E-6302-4435-B6A8-486ABB91EC9E")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class UserToken
{
    [JsonPropertyName("tokenId")]
    public string TokenId { get; set; } = "";

    [JsonPropertyName("expire")]
    public string Expire { get; set; } = "";
}
