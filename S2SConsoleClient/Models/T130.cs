using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T130
    {
        public class Request
        {
            [JsonPropertyName("goodsName")]
            public string GoodsName { get; set; }
            [JsonPropertyName("goodsCode")]
            public string GoodsCode { get; set; }
            [JsonPropertyName("measureUnit")]
            public string MeasureUnit { get; set; }
            [JsonPropertyName("unitPrice")]
            public string UnitPrice { get; set; }
            [JsonPropertyName("currency")]
            public string Currency { get; set; }
            [JsonPropertyName("commodityCategoryId")]
            public string CommodityCategoryId { get; set; }
            [JsonPropertyName("haveExciseTax")]
            public string HaveExciseTax { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("stockPrewarning")]
            public string StockPrewarning { get; set; }
            [JsonPropertyName("pieceMeasureUnit")]
            public string PieceMeasureUnit { get; set; }
            [JsonPropertyName("havePieceUnit")]
            public string HavePieceUnit { get; set; }
            [JsonPropertyName("pieceUnitPrice")]
            public string PieceUnitPrice { get; set; }
            [JsonPropertyName("packageScaledValue")]
            public string PackageScaledValue { get; set; }
            [JsonPropertyName("pieceScaledValue")]
            public string PieceScaledValue { get; set; }
        }

        public class Response
        {
            [JsonPropertyName("commodityCategoryId")]
            public string CommodityCategoryId { get; set; }
            [JsonPropertyName("currency")]
            public string Currency { get; set; }
            [JsonPropertyName("dateFormat")]
            public string DateFormat { get; set; }
            [JsonPropertyName("goodsCode")]
            public string GoodsCode { get; set; }
            [JsonPropertyName("goodsName")]
            public string GoodsName { get; set; }
            [JsonPropertyName("haveExciseTax")]
            public string HaveExciseTax { get; set; }
            [JsonPropertyName("havePieceUnit")]
            public string HavePieceUnit { get; set; }
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("measureUnit")]
            public string MeasureUnit { get; set; }
            [JsonPropertyName("nowTime")]
            public string NowTime { get; set; }
            [JsonPropertyName("packageScaledValue")]
            public string PackageScaledValue { get; set; }
            [JsonPropertyName("pageIndex")]
            public int PageIndex { get; set; }
            [JsonPropertyName("pageNo")]
            public int PageNo { get; set; }
            [JsonPropertyName("pageSize")]
            public int PageSize { get; set; }
            [JsonPropertyName("pieceMeasureUnit")]
            public string PieceMeasureUnit { get; set; }
            [JsonPropertyName("pieceScaledValue")]
            public string PieceScaledValue { get; set; }
            [JsonPropertyName("pieceUnitPrice")]
            public string PieceUnitPrice { get; set; }
            [JsonPropertyName("returnCode")]
            public string ReturnCode { get; set; }
            [JsonPropertyName("returnMessage")]
            public string ReturnMessage { get; set; }
            [JsonPropertyName("stockPrewarning")]
            public string StockPrewarning { get; set; }
            [JsonPropertyName("timeFormat")]
            public string TimeFormat { get; set; }
            [JsonPropertyName("tin")]
            public string Tin { get; set; }
            [JsonPropertyName("unitPrice")]
            public string UnitPrice { get; set; }
        }
        
    }
}
