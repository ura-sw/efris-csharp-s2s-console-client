using System.Text.Json.Serialization;

namespace S2SConsoleClient
{
    public class TaxpayerBranch
    {
        [JsonPropertyName("branchCode")]
        public string BranchCode { get; set; }
        [JsonPropertyName("branchName")]
        public string BranchName { get; set; }
        [JsonPropertyName("branchType")]
        public string BranchType { get; set; }
        [JsonPropertyName("contactName")]
        public string ContactName { get; set; }
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
