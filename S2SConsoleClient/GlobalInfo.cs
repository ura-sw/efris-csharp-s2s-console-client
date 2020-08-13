using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class GlobalInfo
    {
        [JsonPropertyName("appId")]
        public string AppID { get; set; } = "AP04";

        [JsonPropertyName("brn")]
        public string BRN { get; set; }

        [JsonPropertyName("dataExchangeId")]
        public string DataExchangeId { get; set; } = DateTime.Now.ToString("yyyyMMddHHmmss.fffffff");

        [JsonPropertyName("deviceMAC")]
        public string DeviceMAC { get; set; } = "1";

        [JsonPropertyName("deviceNo")]
        public string DeviceNo { get; set; }

        [JsonPropertyName("extendField")]
        public ExtendField ExtendField { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; } = "0";

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; } = "0";

        [JsonPropertyName("interfaceCode")]
        public string InterfaceCode { get; set; }

        [JsonPropertyName("requestCode")]
        public string RequestCode { get; set; } = "TP";

        [JsonPropertyName("requestTime")]
        public string RequestTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        [JsonPropertyName("responseCode")]
        public string ResponseCode { get; set; } = "TA";

        [JsonPropertyName("taxpayerID")]
        public string TaxpayerID { get; set; }

        [JsonPropertyName("tin")]
        public string TIN { get; set; }

        [JsonPropertyName("userName")]
        public string UserName { get; set; } = "admin";

        [JsonPropertyName("version")]
        public string Version { get; set; } = "1.1.20191201";
    }
}
