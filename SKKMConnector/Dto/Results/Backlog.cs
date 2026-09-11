using System;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Данные о непереданных документах
    /// </summary>
    [ComVisible(true)]
    [Guid("B972ABEE-FD32-4771-A854-27683C884D5C")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class Backlog
    {
        /// <summary>
        /// Количество непереданных документов.
        /// </summary>
        [JsonPropertyName("DocumentsCounter")]
        public long DocumentsCounter { get; set; }

        /// <summary>
        /// Номер первого непереданного документа.
        /// </summary>
        [JsonPropertyName("DocumentFirstNumber")]
        public long DocumentFirstNumber { get; set; }

        /// <summary>
        /// Дата и время первого из непереданных документов.
        /// </summary>
        [JsonPropertyName("DocumentFirstDateTime")]
        public DateTime DocumentFirstDateTime { get; set; }
    }
}
