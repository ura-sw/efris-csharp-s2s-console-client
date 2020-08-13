using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T115
    {
        public class Request
        {

        }

        public class Response
        {
            public Response()
            {
                CountryCode = new List<CountryCode>();
                CreditNoteMaximumInvoicingDays = new List<Pair>();
                CreditNoteValuePercentLimit = new List<Pair>();
                CurrencyType = new List<Pair>();
                PayWay = new List<Pair>();
                RateUnit = new List<Pair>();
                VatList = new List<VatList>();
                ExciseDutyList = new List<ExciseDuty>();
                Sector = new List<Sector>();
            }

            [JsonPropertyName("format")]
            public Format Format { get; set; }
            [JsonPropertyName("countryCode")]
            public List<CountryCode> CountryCode { get; set; }
            [JsonPropertyName("creditNoteMaximumInvoicingDays")]
            public List<Pair> CreditNoteMaximumInvoicingDays { get; set; }
            [JsonPropertyName("creditNoteValuePercentLimit")]
            public List<Pair> CreditNoteValuePercentLimit { get; set; }
            [JsonPropertyName("currencyType")]
            public List<Pair> CurrencyType { get; set; }
            [JsonPropertyName("payWay")]
            public List<Pair> PayWay { get; set; }
            [JsonPropertyName("rateUnit")]
            public List<Pair> RateUnit { get; set; }
            [JsonPropertyName("vatList")]
            public List<VatList> VatList { get; set; }
            [JsonPropertyName("exciseDutyList")]
            public List<ExciseDuty> ExciseDutyList { get; set; }
            [JsonPropertyName("sector")]
            public List<Sector> Sector { get; set; }
        }

        public class Sector
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("parentClass")]
            public string ParentClass { get; set; }
            [JsonPropertyName("requiredFill")]
            public string RequiredFill { get; set; }
        }

        public class Format
        {
            [JsonPropertyName("dateFormat")]
            public string dateFormat { get; set; }
            [JsonPropertyName("timeFormat")]
            public string timeFormat { get; set; }
        }

        public class ExciseDuty
        {
            [JsonPropertyName("dateFormat")]
            public string DateFormat { get; set; }
            [JsonPropertyName("effectiveDate")]
            public string EffectiveDate { get; set; }
            [JsonPropertyName("exciseDutyDetailsList")]
            public List<ExciseDutyDetails> ExciseDutyDetailsList { get; set; }
            [JsonPropertyName("goodService")]
            public string GoodService { get; set; }
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("nowTime")]
            public string NowTime { get; set; }
            [JsonPropertyName("pageIndex")]
            public int PageIndex { get; set; }
            [JsonPropertyName("pageNo")]
            public int PageNo { get; set; }
            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }
            [JsonPropertyName("parentClass")]
            public string ParentClass { get; set; }
            [JsonPropertyName("rateText")]
            public string RateText { get; set; }
            [JsonPropertyName("timeFormat")]
            public string TimeFormat { get; set; }
        }

        public class ExciseDutyDetails
        {
            [JsonPropertyName("dateFormat")]
            public string DateFormat { get; set; }
            [JsonPropertyName("exciseDutyId")]
            public string ExciseDutyId { get; set; }
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("nowTime")]
            public string NowTime { get; set; }
            [JsonPropertyName("pageIndex")]
            public int PageTndex { get; set; }
            [JsonPropertyName("pageNo")]
            public int PageNo { get; set; }
            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }
            [JsonPropertyName("rate")]
            public string Rate { get; set; }
            [JsonPropertyName("timeFormat")]
            public string TimeFormat { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        public class VatList
        {
            [JsonPropertyName("effectiveDate")]
            public string Effectivedate { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("parentClass")]
            public string ParentClass { get; set; }
            [JsonPropertyName("rate")]
            public string Rate { get; set; }
            [JsonPropertyName("taxCode")]
            public string TaxCode { get; set; }
            [JsonPropertyName("vatManagement")]
            public string VatManagement { get; set; }
        }

        public class Pair
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        public class CountryCode
        {
            [JsonPropertyName("dateFormat")]
            public string DateFormat { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("nowTime")]
            public string NowTime { get; set; }
            [JsonPropertyName("pageIndex")]
            public int PageIndex { get; set; }
            [JsonPropertyName("pageNo")]
            public int PageNo { get; set; }
            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }
            [JsonPropertyName("timeFormat")]
            public string TimeFormat { get; set; }
            [JsonPropertyName("typeCode")]
            public string TypeCode { get; set; }
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }


    }
}
