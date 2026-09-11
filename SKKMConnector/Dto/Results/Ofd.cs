using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Оператор фискальных данных (Ofd).
    /// </summary>
    [ComVisible(true)]
    [Guid("9A34FF1F-0DE1-488F-B6D6-AFA50330BDC4")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class Ofd
    {
        /// <summary>
        /// Имя ОФД.
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// ИНН ОФД.
        /// </summary>
        [JsonPropertyName("Vatin")]
        public string? Vatin { get; set; }
    }
}
