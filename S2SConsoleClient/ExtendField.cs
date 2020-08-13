using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class ExtendField
    {
        [JsonPropertyName("resposeDateFormat")]
        public string ResposeDateFormat { get; set; }

        [JsonPropertyName("resposeTimeFormat")]
        public string ResposeTimeFormat { get; set; }
    }
}
