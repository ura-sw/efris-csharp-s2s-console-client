using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class Response
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("globalInfo")]
        public GlobalInfo GlobalInfo { get; set; }

        [JsonPropertyName("returnStateInfo")]
        public ReturnStateInfo ReturnStateInfo { get; set; }
    }
}
