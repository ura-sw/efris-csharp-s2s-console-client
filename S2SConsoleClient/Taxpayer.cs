using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class Taxpayer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("tin")]
        public string Tin { get; set; }
        [JsonPropertyName("legalName")]
        public string LegalName { get; set; }
        [JsonPropertyName("businessName")]
        public string BusinessName { get; set; }
        [JsonPropertyName("taxpayerStatusId")]
        public string TaxpayerStatusId { get; set; }
        [JsonPropertyName("taxpayerRegistrationStatusId")]
        public string TaxpayerRegistrationStatusId { get; set; }
        [JsonPropertyName("taxpayerType")]
        public string TaxpayerType { get; set; }
        [JsonPropertyName("departmentId")]
        public string DepartmentId { get; set; }
        [JsonPropertyName("contactEmail")]
        public string ContactEmail { get; set; }
        [JsonPropertyName("contactMobile")]
        public string ContactMobile { get; set; }
        [JsonPropertyName("contactNumber")]
        public string ContactNumber { get; set; }
        [JsonPropertyName("placeOfBusiness")]
        public string PlaceOfBusiness { get; set; }
    }
}
