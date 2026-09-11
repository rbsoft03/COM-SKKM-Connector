using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Итоги текущей кассовой смены
    /// </summary>
    [ComVisible(true)]
    [Guid("B78849EE-CD64-490C-98A1-E2C1971AA601")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ResShiftTotal
    {
        /// <summary>
        /// Номер смены.
        /// </summary>
        [JsonPropertyName("ShiftNumber")]
        public double ShiftNumber { get; set; }

        /// <summary>
        /// Денежный ящик: остаток наличных и число операций.
        /// </summary>
        [JsonPropertyName("CashDrawer")]
        public CashDrawer? CashDrawer { get; set; }

        /// <summary>
        /// Внесения за смену.
        /// </summary>
        [JsonPropertyName("ShiftIncome")]
        public ShiftIncome? ShiftIncome { get; set; }

        /// <summary>
        /// Выемки за смену.
        /// </summary>
        [JsonPropertyName("ShiftOutcome")]
        public ShiftIncome? ShiftOutcome { get; set; }

        /// <summary>
        /// Счетчики фискальных операций за смену
        /// </summary>
        [JsonPropertyName("Counters")]
        public ShiftCounters? Counters { get; set; }
    }
}
