using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace S2SConsoleClient.Models
{
    public class T108
    {
        public class Request
        {
            [JsonPropertyName("invoiceNo")]
            public string InvoiceNo { get; set; }
        }

        public class Response
        {

        }
    }
}
