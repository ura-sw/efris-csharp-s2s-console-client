using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T103
    {
        public T103()
        {
            Device = new Device();
            Taxpayer = new Taxpayer();
            TaxpayerBranch = new TaxpayerBranch();
            TaxTypes = new List<TaxType>();
        }

        [JsonPropertyName("device")]
        public Device Device { get; set; }

        [JsonPropertyName("taxpayer")]
        public Taxpayer Taxpayer { get; set; }

        [JsonPropertyName("taxpayerBranch")]
        public TaxpayerBranch TaxpayerBranch { get; set; }

        [JsonPropertyName("taxType")]
        public List<TaxType> TaxTypes { get; set; }

        [JsonPropertyName("dictionaryVersion")]
        public string DictionaryVersion { get; set; }
        [JsonPropertyName("issueTaxTypeRestrictions")]
        public string IssueTaxTypeRestrictions { get; set; }
        [JsonPropertyName("taxpayerBranchVersion")]
        public string TaxpayerBranchVersion { get; set; }
        [JsonPropertyName("commodityCategoryVersion")]
        public string CommodityCategoryVersion { get; set; }
        [JsonPropertyName("exciseDutyVersion")]
        public string ExciseDutyVersion { get; set; }
        [JsonPropertyName("sellersLogo")]
        public string SellersLogo { get; set; }
        [JsonPropertyName("goodsStockLimit")]
        public string GoodsStockLimit { get; set; }
        [JsonPropertyName("whetherEnableServerStock")]
        public string WhetherEnableServerStock { get; set; }
    }
}
