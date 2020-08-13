using System;
using System.Collections.Generic;
using System.Text;

namespace S2SConsoleClient.Models
{
    public class T129
    {
        public class Request
        {
            public Request()
            {
                Invoices = new List<InvoiceItem>();
            }
            public List<InvoiceItem> Invoices { get; set; }
        }

        public class InvoiceItem
        {
            public string InvoiceContent { get; set; }
            public string InvoiceSignature { get; set; }
        }

        public class Response
        {

        }
        
    }
}
