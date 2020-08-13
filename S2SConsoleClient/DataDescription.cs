using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class DataDescription
    {
        [JsonPropertyName("codeType")]
        public string CodeType { get; set; } = "0";

        [JsonPropertyName("encryptCode")]
        public string EncryptCode { get; set; } = "0";

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; } = "0";
    }
}
