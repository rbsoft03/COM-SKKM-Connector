using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Результат локальной проверки кода маркировки 
    /// </summary>
    [ComVisible(true)]
    [Guid("286C2F7D-ABE3-4820-A9EA-24A17EC61819")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class RequestKmResult
    {
        /// <summary>
        /// Признак наличия связи с ОИСМ на момент отправки запроса.
        /// </summary>
        [JsonPropertyName("ISMConnected")]
        public bool IsmConnected { get; set; }

        /// <summary>
        /// Признак того, что проверка формата кода маркировки прошла успешно.
        /// </summary>
        [JsonPropertyName("FormatChecking")]
        public bool FormatChecking { get; set; }

        /// <summary>
        /// Признак того, что проверка кода маркировки поставлена в обработку.
        /// </summary>
        [JsonPropertyName("Checking")]
        public bool Checking { get; set; }

        /// <summary>
        /// Результат проверки, если он уже доступен на момент ответа.
        /// </summary>
        [JsonPropertyName("CheckingResult")]
        public bool CheckingResult { get; set; }

        /// <summary>
        /// Штрихкод после приведения к виду со спецсимволами GS.
        /// </summary>
        [JsonPropertyName("Barcode")]
        public string? Barcode { get; set; }
    }
}
