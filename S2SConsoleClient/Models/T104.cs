using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T104
    {
        [JsonPropertyName("passowrdDes")]
        public string PasswordAes { get; set; }

        [JsonPropertyName("sign")]
        public string Signature { get; set; }
    }
}
