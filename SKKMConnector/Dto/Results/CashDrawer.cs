using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Состояние денежного ящика: сумма наличных и число операций.
    /// </summary>
    [ComVisible(true)]
    [Guid("5740784F-A1C5-47FD-9684-CE40050FDE49")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class CashDrawer
    {
        /// <summary>
        /// Сумма наличных в ящике.
        /// </summary>
        [JsonPropertyName("Sum")]
        public decimal Sum { get; set; }

        /// <summary>
        /// Количество операций с наличными.
        /// </summary>
        [JsonPropertyName("Count")]
        public int Count { get; set; }
    }
}
