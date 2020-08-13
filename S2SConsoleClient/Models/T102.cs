using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T102
    {
        [JsonPropertyName("clientPriKey")]
        public string ClientPrivateKey { get; set; }

        [JsonPropertyName("serverPubKey")]
        public string ServerPublicKey { get; set; }

        [JsonPropertyName("keyTable")]
        public string KeyTable { get; set; }
    }
}
