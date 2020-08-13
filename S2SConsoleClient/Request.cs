using S2SConsoleClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class Request
    {
        public Request(Config config)
        {
            Data = new Data();
            GlobalInfo = new GlobalInfo();
            GlobalInfo.TIN = config.Tin;
            GlobalInfo.TaxpayerID = config.TaxpayerID;
            GlobalInfo.DeviceNo = config.DeviceNo;
            ReturnStateInfo = new ReturnStateInfo();
        }

        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("globalInfo")]
        public GlobalInfo GlobalInfo { get; set; }

        [JsonPropertyName("returnStateInfo")]
        public ReturnStateInfo ReturnStateInfo { get; set; }
    }
}
