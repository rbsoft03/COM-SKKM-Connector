using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Описание драйвера ККМ 
    /// </summary>
    [ComVisible(true)]
    [Guid("A27E6E6E-EAC3-46A9-9A56-A8C232E61132")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class Driver
    {
        /// <summary>
        /// Тип драйвера.
        /// </summary>
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        /// <summary>
        /// Версия драйвера
        /// </summary>
        [JsonPropertyName("Version")]
        public string? Version { get; set; }

        /// <summary>
        /// Данные поставщика.
        /// </summary>
        [JsonPropertyName("Vendor")]
        public string? Vendor { get; set; }
    }
}
