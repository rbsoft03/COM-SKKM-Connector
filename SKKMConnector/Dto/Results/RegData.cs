using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Счётчик скидок или надбавок
    /// </summary>
    [ComVisible(true)]
    [Guid("FC78193E-1677-484F-857D-88AD39480167")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class RegData
    {
        /// <summary>
        /// Количество операций (скидок или надбавок).
        /// </summary>
        [JsonPropertyName("Count")]
        public int Count { get; set; }

        /// <summary>
        /// Сумма операций.
        /// </summary>
        [JsonPropertyName("Sum")]
        public decimal Sum { get; set; }
    }
}
