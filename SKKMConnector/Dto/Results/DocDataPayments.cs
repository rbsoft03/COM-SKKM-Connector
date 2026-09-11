using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Разбивка суммы операций по видам оплаты 
    /// </summary>
    [ComVisible(true)]
    [Guid("CE9F54B8-1E90-4F25-B3F6-E7CF1A3FD96E")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class DocDataPayments
    {
        /// <summary>
        /// Общая сумма оплат.
        /// </summary>
        [JsonPropertyName("Sum")]
        public decimal Sum { get; set; }

        /// <summary>
        /// Наличные
        /// </summary>
        [JsonPropertyName("Cash")]
        public decimal Cash { get; set; }

        /// <summary>
        /// Безналичные
        /// </summary>
        [JsonPropertyName("Electronically")]
        public decimal Electronically { get; set; }

        /// <summary>
        /// Аванс (предоплата).
        /// </summary>
        [JsonPropertyName("Prepaid")]
        public decimal Prepaid { get; set; }

        /// <summary>
        /// Кредит (постоплата).
        /// </summary>
        [JsonPropertyName("Credit")]
        public decimal Credit { get; set; }

        /// <summary>
        /// Встречные предоставления (бартер).
        /// </summary>
        [JsonPropertyName("Barter")]
        public decimal Barter { get; set; }
    }
}
