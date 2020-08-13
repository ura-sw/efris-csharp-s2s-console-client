using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T109
    {
        public class Request
        {
            public Request()
            {
                SellerDetails = new SellerDetails();
                BasicInformation = new BasicInformation();
                BuyerDetails = new BuyerDetails();
                GoodsDetails = new List<GoodsItem>();
                TaxDetails = new List<TaxDetail>();
                Summary = new Summary();
                PayWay = new List<Payment>();
                Extend = new Extend();
            }

            [JsonPropertyName("sellerDetails")]
            public SellerDetails SellerDetails { get; set; }
            [JsonPropertyName("basicInformation")]
            public BasicInformation BasicInformation { get; set; }
            [JsonPropertyName("buyerDetails")]
            public BuyerDetails BuyerDetails { get; set; }
            [JsonPropertyName("goodsDetails")]
            public List<GoodsItem> GoodsDetails { get; set; }
            [JsonPropertyName("taxDetails")]
            public List<TaxDetail> TaxDetails { get; set; }
            [JsonPropertyName("summary")]
            public Summary Summary { get; set; }
            [JsonPropertyName("payWay")]
            public List<Payment> PayWay { get; set; }
            [JsonPropertyName("extend")]
            public Extend Extend { get; set; }
        }

        public class Response
        {

        }

        public class SellerDetails
        {
            [JsonPropertyName("tin")]
            public string Tin { get; set; }
            [JsonPropertyName("ninBrn")]
            public string NinBrn { get; set; } = "";
            [JsonPropertyName("legalName")]
            public string LegalName { get; set; } = "HUAWEI TECHNOLOGIES UGANDA CO LIMITED";
            [JsonPropertyName("businessName")]
            public string BusinessName { get; set; } = "HUAWEI TECHNOLOGIES UGANDA CO LIMITED";
            [JsonPropertyName("address")]
            public string Address { get; set; } = "5-7 COOPER ROAD KISEMENTI THE CUBE 8TH FLOOR KAMAPALA KAMPALA KAMPALA CENTRAL DIVI KAMPALA CENTRAL DIVISION KOLOLO II";
            [JsonPropertyName("mobilePhone")]
            public string MobilePhone { get; set; } = "256772140067";
            [JsonPropertyName("linePhone")]
            public string LinePhone { get; set; } = "256772140067";
            [JsonPropertyName("emailAddress")]
            public string EmailAddress { get; set; } = "ewakoko@ura.go.ug";
            [JsonPropertyName("placeOfBusiness")]
            public string PlaceOfBusiness { get; set; } = "5-7 COOPER ROAD KISEMENTI THE CUBE 8TH FLOOR KAMAPALA KAMPALA KAMPALA CENTRAL DIVI KAMPALA CENTRAL DIVISION KOLOLO II";
            [JsonPropertyName("referenceNo")]
            public string ReferenceNo { get; set; } = "Huawei";
        }

        public class BasicInformation
        {
            [JsonPropertyName("invoiceNo")]
            public string InvoiceNumber { get; set; }
            [JsonPropertyName("antifakeCode")]
            public string AntifakeCode { get; set; }
            [JsonPropertyName("deviceNo")]
            public string DeviceNo { get; set; }
            [JsonPropertyName("issuedDate")]
            public string IssuedDate { get; set; }
            [JsonPropertyName("operator")]
            public string Operator { get; set; }
            [JsonPropertyName("currency")]
            public string Currency { get; set; } = "UGX";
            [JsonPropertyName("oriInvoiceId")]
            public string OriInvoiceId { get; set; }
            [JsonPropertyName("invoiceType")]
            public string InvoiceType { get; set; }
            [JsonPropertyName("invoiceKind")]
            public string InvoiceKind { get; set; }
            [JsonPropertyName("dataSource")]
            public string DataSource { get; set; }
            [JsonPropertyName("invoiceIndustryCode")]
            public string InvoiceIndustryCode { get; set; }
        }

        public class BuyerDetails
        {
            [JsonPropertyName("buyerTin")]
            public string BuyerTin { get; set; }
            [JsonPropertyName("buyerNinBrn")]
            public string BuyerNinBrn { get; set; }
            [JsonPropertyName("buyerPassportNum")]
            public string BuyerPassportNum { get; set; } = "David Wakoko";
            [JsonPropertyName("buyerLegalName")]
            public string BuyerLegalName { get; set; }
            [JsonPropertyName("buyerBusinessName")]
            public string BuyerBusinessName { get; set; }
            [JsonPropertyName("buyerAddress")]
            public string BuyerAddress { get; set; }
            [JsonPropertyName("buyerEmail")]
            public string BuyerEmail { get; set; }
            [JsonPropertyName("buyerMobilePhone")]
            public string BuyerMobilePhone { get; set; } = "256772803934";
            [JsonPropertyName("buyerLinePhone")]
            public string BuyerLinePhone { get; set; }
            [JsonPropertyName("buyerPlaceOfBusi")]
            public string BuyerPlaceOfBusiness { get; set; }
            [JsonPropertyName("buyerType")]
            public string BuyerType { get; set; }
            [JsonPropertyName("buyerCitizenship")]
            public string BuyerCitizenship { get; set; }
            [JsonPropertyName("buyerSector")]
            public string BuyerSector { get; set; }
            [JsonPropertyName("buyerReferenceNo")]
            public string BuyerReferenceNo { get; set; }
        }

        public class GoodsDetails
        {
            public GoodsItem[] GoodsItems { get; set; }
        }

        public class GoodsItem
        {
            [JsonPropertyName("item")]
            public string Item { get; set; }
            [JsonPropertyName("itemCode")]
            public string ItemCode { get; set; }
            [JsonPropertyName("qty")]
            public string Quantity { get; set; }
            [JsonPropertyName("unitOfMeasure")]
            public string UnitOfMeasure { get; set; }
            [JsonPropertyName("unitPrice")]
            public string UnitPrice { get; set; }
            [JsonPropertyName("total")]
            public string Total { get; set; }
            [JsonPropertyName("taxRate")]
            public string TaxRate { get; set; }
            [JsonPropertyName("tax")]
            public string Tax { get; set; }
            [JsonPropertyName("discountTotal")]
            public string DiscountTotal { get; set; }
            [JsonPropertyName("discountTaxRate")]
            public string DiscountTaxRate { get; set; }
            [JsonPropertyName("orderNumber")]
            public string OrderNumber { get; set; }
            [JsonPropertyName("discountFlag")]
            public string DiscountFlag { get; set; }
            [JsonPropertyName("deemedFlag")]
            public string DeemedFlag { get; set; }
            [JsonPropertyName("exciseFlag")]
            public string ExciseFlag { get; set; }
            [JsonPropertyName("categoryId")]
            public string CategoryId { get; set; }
            [JsonPropertyName("categoryName")]
            public string CategoryName { get; set; }
            [JsonPropertyName("goodsCategoryId")]
            public string GoodsCategoryId { get; set; }
            [JsonPropertyName("goodsCategoryName")]
            public string GoodsCategoryName { get; set; }
            [JsonPropertyName("exciseRate")]
            public string ExciseRate { get; set; }
            [JsonPropertyName("exciseRule")]
            public string ExciseRule { get; set; }
            [JsonPropertyName("exciseTax")]
            public string ExciseTax { get; set; }
            [JsonPropertyName("pack")]
            public string Pack { get; set; }
            [JsonPropertyName("stick")]
            public string Stick { get; set; }
            [JsonPropertyName("exciseUnit")]
            public string ExciseUnit { get; set; }
            [JsonPropertyName("exciseCurrency")]
            public string ExciseCurrency { get; set; }
            [JsonPropertyName("exciseRateName")]
            public string ExciseRateName { get; set; }
        }

        public class TaxDetail
        {
            [JsonPropertyName("taxCategory")]
            public string TaxCategory { get; set; }
            [JsonPropertyName("netAmount")]
            public string NetAmount { get; set; }
            [JsonPropertyName("taxRate")]
            public string TaxRate { get; set; }
            [JsonPropertyName("taxAmount")]
            public string TaxAmount { get; set; }
            [JsonPropertyName("grossAmount")]
            public string GrossAmount { get; set; }
            [JsonPropertyName("exciseUnit")]
            public string ExciseUnit { get; set; }
            [JsonPropertyName("exciseCurrency")]
            public string ExciseCurrency { get; set; }
            [JsonPropertyName("taxRateName")]
            public string TaxRateName { get; set; }
        }

        public class Summary
        {
            [JsonPropertyName("netAmount")]
            public string NetAmount { get; set; }
            [JsonPropertyName("taxAmount")]
            public string TaxAmount { get; set; }
            [JsonPropertyName("grossAmount")]
            public string GrossAmount { get; set; }
            [JsonPropertyName("itemCount")]
            public string ItemCount { get; set; }
            [JsonPropertyName("modeCode")]
            public string ModeCode { get; set; }
            [JsonPropertyName("remarks")]
            public string Remarks { get; set; }
            [JsonPropertyName("qrCode")]
            public string QrCode { get; set; }
        }

        public class Payment
        {
            [JsonPropertyName("paymentMode")]
            public string PaymentMode { get; set; }
            [JsonPropertyName("paymentAmount")]
            public string PaymentAmount { get; set; }
            [JsonPropertyName("orderNumber")]
            public string OrderNumber { get; set; }
        }

        public class Extend
        {
            [JsonPropertyName("reason")]
            public string Reason { get; set; }
            [JsonPropertyName("reasonCode")]
            public string ReasonCode { get; set; }
        }
    }
}
