using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class TaxType
    {
        [JsonPropertyName("taxTypeName")]
        public string TaxTypeName { get; set; }
        [JsonPropertyName("taxTypeCode")]
        public string TaxTypeCode { get; set; }
        [JsonPropertyName("registrationDate")]
        public string RegistrationDate { get; set; }
    }
}
