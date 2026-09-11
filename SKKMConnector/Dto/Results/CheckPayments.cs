using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Оплаты из ответа сервера (Payments)
/// </summary>
[ComVisible(true)]
[Guid("ADE3AF58-E5A7-4D52-8137-2A68A842D75B")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class CheckPayments
{
    /// <summary>
    /// Сумма наличной оплаты.
    /// </summary>
    [JsonPropertyName("Cash")]
    public decimal Cash { get; set; }

    /// <summary>
    /// Сумма безналичными средствами.
    /// </summary>
    [JsonPropertyName("Electronic")]
    public decimal Electronic { get; set; }

    /// <summary>
    /// Сумма предоплатой (зачётом аванса).
    /// </summary>
    [JsonPropertyName("PrePaid")]
    public decimal PrePaid { get; set; }

    /// <summary>
    /// Сумма постоплатой (в кредит).
    /// </summary>
    [JsonPropertyName("Credit")]
    public decimal Credit { get; set; }

    /// <summary>
    /// Сумма встречным предоставлением.
    /// </summary>
    [JsonPropertyName("Barter")]
    public decimal Barter { get; set; }
}
