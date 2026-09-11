using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Счетчик документов
    /// </summary>
    [ComVisible(true)]
    [Guid("F9463F9F-7903-4306-A1B4-ABFC45932F74")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class DocData
    {
        /// <summary>
        /// Количество документов
        /// </summary>
        [JsonPropertyName("Count")]
        public int Count { get; set; }

        /// <summary>
        /// Сумма по документам
        /// </summary>
        [JsonPropertyName("Sum")]
        public decimal Sum { get; set; }

        /// <summary>
        /// Разбивка суммы по видам оплаты 
        /// </summary>
        [JsonPropertyName("Payments")]
        public DocDataPayments? Payments { get; set; }

        /// <summary>
        /// Скидки: количество и сумма.
        /// </summary>
        [JsonPropertyName("Discount")]
        public RegData? Discount { get; set; }

        /// <summary>
        /// Надбавки (наценки): количество и сумма.
        /// </summary>
        [JsonPropertyName("Adding")]
        public RegData? Adding { get; set; }
    }
}
