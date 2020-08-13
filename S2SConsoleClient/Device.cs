using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class Device
    {
        [JsonPropertyName("branchCode")]
        public string BranchCode { get; set; }
        [JsonPropertyName("branchId")]
        public string BranchId { get; set; }
        [JsonPropertyName("deviceModel")]
        public string DeviceModel { get; set; }
        [JsonPropertyName("deviceNo")]
        public string DeviceNo { get; set; }
        [JsonPropertyName("deviceStatus")]
        public string DeviceStatus { get; set; }
        [JsonPropertyName("offlineAmount")]
        public string OfflineAmount { get; set; }
        [JsonPropertyName("offlineDays")]
        public string OfflineDays { get; set; }
        [JsonPropertyName("offlineValue")]
        public string OfflineValue { get; set; }
    }
}
