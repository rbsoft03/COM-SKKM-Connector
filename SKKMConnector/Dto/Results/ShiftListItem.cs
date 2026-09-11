using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm;

/// <summary>
/// Элемент списка отчётов
/// </summary>
[ComVisible(true)]
[Guid("BD089AD1-150D-46A1-B7E5-2C1344404F24")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public sealed class ShiftListItem
{
    /// <summary>
    /// Результат обработки.
    /// </summary>
    [JsonPropertyName("ResultCode")]
    public int ResultCode { get; set; }

    /// <summary>
    /// Описание результата.
    /// </summary>
    [JsonPropertyName("ResultDescription")]
    public string? ResultDescription { get; set; }

    /// <summary>
    /// Дата создания документа.
    /// </summary>
    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }

    /// <summary>
    /// Идентификатор документа.
    /// </summary>
    [JsonPropertyName("DocId")]
    public string? DocId { get; set; }

    /// <summary>
    /// Номер сессии (смены).
    /// </summary>
    [JsonPropertyName("ShiftNumber")]
    public int ShiftNumber { get; set; }

    /// <summary>
    /// Имя устройства.
    /// </summary>
    [JsonPropertyName("DeviceName")]
    public string? DeviceName { get; set; }

    /// <summary>
    /// Идентификатор терминала, с которого пришёл документ.
    /// </summary>
    [JsonPropertyName("TerminalId")]
    public string? TerminalId { get; set; }
}
