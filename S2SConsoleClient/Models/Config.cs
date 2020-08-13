using System;
using System.Collections.Generic;
using System.Text;

namespace S2SConsoleClient.Models
{
    public class Config
    {
        public string ApiUrl { get; set; }
        public string EFRISPublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string SessionAESKey { get; set; }
        public string TaxpayerID { get; set; }
        public string Tin { get; set; }
        public string DeviceNo { get; set; }
    }
}
