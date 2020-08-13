using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class ReturnStateInfo
    {
        [JsonPropertyName("returnCode")]
        public string ReturnCode { get; set; }

        [JsonPropertyName("returnMessage")]
        public string ReturnMessage { get; set; }
    }
}
