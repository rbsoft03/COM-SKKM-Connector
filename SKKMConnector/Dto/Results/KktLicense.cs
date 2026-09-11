using System;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace RBSoftSkkm
{
    /// <summary>
    /// Лицензия ККТ 
    /// </summary>
    [ComVisible(true)]
    [Guid("F44F5A95-6D58-42D9-9955-D44F539E9849")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class KktLicense
    {
        /// <summary>
        /// Номер лицензии.
        /// </summary>
        [JsonPropertyName("Number")]
        public int Number { get; set; }

        /// <summary>
        /// Наименование лицензии.
        /// </summary>
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        /// <summary>
        /// Действует с.
        /// </summary>
        [JsonPropertyName("ValidFrom")]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Действует до.
        /// </summary>
        [JsonPropertyName("ValidUntil")]
        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// Версия узла
        /// </summary>
        [JsonPropertyName("UnitVersion")]
        public string? UnitVersion { get; set; }

        /// <summary>
        /// Описание лицензии.
        /// </summary>
        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        /// <summary>
        /// Признак активной лицензии.
        /// </summary>
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
    }
}
