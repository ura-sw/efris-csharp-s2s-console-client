using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class Data
    {
        public Data()
        {
            DataDescription = new DataDescription();
        }

        [JsonPropertyName("content")]
        public string Content { get; set; } = "";

        [JsonPropertyName("signature")]
        public string Signature { get; set; } = "";

        [JsonPropertyName("dataDescription")]
        public DataDescription DataDescription { get; set; }
    }
}
