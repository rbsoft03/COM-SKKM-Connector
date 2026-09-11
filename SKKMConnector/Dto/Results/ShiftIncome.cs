using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Итог внесений или выемок за смену
    /// </summary>
    [ComVisible(true)]
    [Guid("99157575-E48F-458E-A478-E8C8B889DF52")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ShiftIncome
    {
        /// <summary>
        /// Количество операций 
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
