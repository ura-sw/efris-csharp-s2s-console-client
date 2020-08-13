using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T101
    {
        [JsonPropertyName("currentTime")]
        public string CurrentTime { get; set; }
    }
}
