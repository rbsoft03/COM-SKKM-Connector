using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Предупреждения ФН 
    /// </summary>
    [ComVisible(true)]
    [Guid("27888CC8-103C-480B-B83A-6CD2E6C67C86")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class Warnings
    {
        /// <summary>
        /// Критическая ошибка ФН.
        /// </summary>
        [JsonPropertyName("CriticalError")]
        public bool CriticalError { get; set; }

        /// <summary>
        /// Память ФН переполнена.
        /// </summary>
        [JsonPropertyName("MemoryOverflow")]
        public bool MemoryOverflow { get; set; }

        /// <summary>
        /// Требуется срочная замена ФН.
        /// </summary>
        [JsonPropertyName("NeedReplacement")]
        public bool NeedReplacement { get; set; }

        /// <summary>
        /// Превышено время ожидания ответа от ОФД.
        /// </summary>
        [JsonPropertyName("OfdTimeout")]
        public bool OfdTimeout { get; set; }

        /// <summary>
        /// Исчерпан ресурс ФН.
        /// </summary>
        [JsonPropertyName("ResourceExhausted")]
        public bool ResourceExhausted { get; set; }
    }
}
