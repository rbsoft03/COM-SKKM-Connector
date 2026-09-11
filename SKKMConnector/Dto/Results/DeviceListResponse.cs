using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Элемент списка ККТ 
    /// </summary>
    [ComVisible(true)]
    [Guid("5F5BDB2E-1A69-4923-B3AA-E336AC672C05")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class DeviceListResponse
    {
        /// <summary>
        /// Имя устройства.
        /// </summary>
        [JsonPropertyName("DeviceName")]
        public string? DeviceName { get; set; }

        /// <summary>
        /// Тип драйвера
        /// </summary>
        [JsonPropertyName("Driver")]
        public DeviceType Driver { get; set; }

        /// <summary>
        /// Имя пула, в который входит устройство.
        /// </summary>
        [JsonPropertyName("Pool")]
        public string? Pool { get; set; }

        /// <summary>
        /// Описание статуса устройства.
        /// </summary>
        [JsonPropertyName("DeviceStatusDescription")]
        public string? DeviceStatusDescription { get; set; }
    }
}
