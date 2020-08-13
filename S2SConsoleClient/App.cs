using Microsoft.Extensions.Configuration;
using S2SConsoleClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace S2SConsoleClient
{
    class App
    {
        private readonly IConfiguration _config;
        private Config appConfig;

        public App(IConfiguration config)
        {
            _config = config;
            appConfig = _config.GetSection("config").Get<Config>();
        }

        public void Run()
        {
            //T101
            var response = GetCurrentTime();
            //T102
            //var response = ClientInit();
            //T103
            //var response = SignIn();
            //T104
            //var response = GetSymmetricKeyAndSignature();
            //T108
            //var response = QueryInvoice("23455657");
            //T109
            //var response = SendInvoice();
            //T115
            //var response = UpdateDictionary();
            //T125
            //var response = QueryExciseDuty();
            //T129
            //var response = UploadBatch();
            //T130
            //var response = UploadGoods();
            Console.WriteLine("Response: " + JsonSerializer.Serialize(response));
        }

        public object SendRequest(Request body)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(appConfig.ApiUrl);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string serializedRequest = JsonSerializer.Serialize(body);
                Console.WriteLine("Serialized Request: " + serializedRequest);
                streamWriter.Write(serializedRequest);
            }

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            string responseBody = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    responseBody = sr.ReadToEnd();
                }
            }
            var encodedResult = JsonSerializer.Deserialize<Response>(responseBody);
            // Todo: If AES key is expired (ResponseCode: 402), get a new key and retry the call.

            return ProcessResponse(GetDataContent(encodedResult.Data), encodedResult.GlobalInfo.InterfaceCode);
        }

        public object ProcessResponse(string decodedResponseJson, string interfaceCode)
        {
            switch (interfaceCode)
            {
                case "T101":
                    return JsonSerializer.Deserialize<T101>(decodedResponseJson);
                case "T102":
                    return JsonSerializer.Deserialize<T102>(decodedResponseJson);
                case "T103":
                    return JsonSerializer.Deserialize<T103>(decodedResponseJson);
                case "T104":
                    return JsonSerializer.Deserialize<T104>(decodedResponseJson);
                case "T108":
                    return JsonSerializer.Deserialize<T108.Response>(decodedResponseJson);
                case "T109":
                    return JsonSerializer.Deserialize<T109.Response>(decodedResponseJson);
                case "T115":
                    return JsonSerializer.Deserialize<T115.Response>(decodedResponseJson);
                case "T125":
                    return JsonSerializer.Deserialize<T108.Response>(decodedResponseJson);
                case "T130":
                    return JsonSerializer.Deserialize<List<T130.Response>>(decodedResponseJson);
                default:
                    return new object();
            }
        }

        private string GetDataContent(Data data)
        {
            string content = data.Content;
            byte[] decodedContent = Convert.FromBase64String(content);
            
            if(data.DataDescription.ZipCode == "1")
            {
                MemoryStream decompressedStream = new MemoryStream();
                using (GZipStream decompressionStream = new GZipStream(new MemoryStream(decodedContent), CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedStream);
                }
                decodedContent = decompressedStream.ToArray();

            }

            if (data.DataDescription.EncryptCode == "2")
            {
                decodedContent = EncryptionHelper.Decrypt(decodedContent, Convert.FromBase64String(File.ReadAllText(appConfig.SessionAESKey)));
            }

            return Encoding.UTF8.GetString(decodedContent);
        }

        public T101 GetCurrentTime()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T101";
            return (T101) SendRequest(request);
        }

        public T108.Response QueryInvoice(string InvoiceNo)
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T108";
            T108.Request rq = new T108.Request();
            rq.InvoiceNo = InvoiceNo;

            string serializedInvoice = JsonSerializer.Serialize(rq, new JsonSerializerOptions { IgnoreNullValues = true });
            Console.WriteLine("Serialized Invoice Query: " + serializedInvoice);
            byte[] serializedRequestBytes = Encoding.UTF8.GetBytes(serializedInvoice);
            request.Data.Content = Convert.ToBase64String(EncryptionHelper.Encrypt(serializedRequestBytes, Convert.FromBase64String(File.ReadAllText(appConfig.SessionAESKey))));
            byte[] privateKey = Convert.FromBase64String(File.ReadAllText(appConfig.PrivateKey));
            using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsaCng = new RSACng(signingKey))
            {
                request.Data.Signature = Convert.ToBase64String(rsaCng.SignData(Encoding.UTF8.GetBytes(request.Data.Content), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
            }

            return (T108.Response) SendRequest(request);
        }

        public T108.Response QueryExciseDuty()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T125";
            return (T108.Response) SendRequest(request);
        }

        public T102 ClientInit()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T102";
            T102 response = (T102) SendRequest(request);
            File.WriteAllText(appConfig.EFRISPublicKey, response.ServerPublicKey);
            string initializationAESKey = appConfig.TaxpayerID.Substring(0, 10) + DateTime.Now.ToString("ddMMy");
            File.WriteAllText(appConfig.PrivateKey, Encoding.UTF8.GetString(EncryptionHelper.Decrypt(Convert.FromBase64String(response.ClientPrivateKey), Encoding.UTF8.GetBytes(initializationAESKey))));
            return response;
        }

        public T103 SignIn()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T103";
            return (T103) SendRequest(request);
        }

        public T115.Response UpdateDictionary()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T115";
            return (T115.Response) SendRequest(request);
        }

        public T104 GetSymmetricKeyAndSignature()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T104";
            T104 response = (T104) SendRequest(request);
            byte[] privateKey = Convert.FromBase64String(File.ReadAllText(appConfig.PrivateKey));
            using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsaCng = new RSACng(signingKey))
            {
                byte[] decryptedAESKey = rsaCng.Decrypt(Convert.FromBase64String(response.PasswordAes), RSAEncryptionPadding.Pkcs1);
                string AESKey = Encoding.UTF8.GetString(decryptedAESKey);
                File.WriteAllText(appConfig.SessionAESKey, AESKey);
            }
            return response;
        }

        T129.Response UploadBatch()
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T129";
            T129.Request batchRequest = new T129.Request();
            byte[] privateKey = Convert.FromBase64String(File.ReadAllText(appConfig.PrivateKey));
            for (var i = 0; i < 5; i++)
            {
                T129.InvoiceItem invoiceItem = new T129.InvoiceItem();
                T109.Request invoice = CreateInvoice();
                invoiceItem.InvoiceContent = JsonSerializer.Serialize(invoice, new JsonSerializerOptions { IgnoreNullValues = true });
                using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
                using (RSACng rsaCng = new RSACng(signingKey))
                {
                    invoiceItem.InvoiceSignature = Convert.ToBase64String(rsaCng.SignData(Encoding.UTF8.GetBytes(invoiceItem.InvoiceContent), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
                }
                batchRequest.Invoices.Add(invoiceItem);
            }
            string serializedInvoice = JsonSerializer.Serialize(batchRequest.Invoices, new JsonSerializerOptions { IgnoreNullValues = true });
            Console.WriteLine("Serialized Invoice: " + serializedInvoice);
            byte[] serializedRequestBytes = Encoding.UTF8.GetBytes(serializedInvoice);
            request.Data.Content = Convert.ToBase64String(EncryptionHelper.Encrypt(serializedRequestBytes, Convert.FromBase64String(File.ReadAllText(appConfig.SessionAESKey))));
            using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsaCng = new RSACng(signingKey))
            {
                request.Data.Signature = Convert.ToBase64String(rsaCng.SignData(Encoding.UTF8.GetBytes(request.Data.Content), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
            }
            var response = (T129.Response) SendRequest(request);
            return response;
        }

        public List<T130.Response> UploadGoods()
        {
            List<T130.Request> goodsUpload = new List<T130.Request>();
            T130.Request stockItem = new T130.Request
            {
                GoodsName = "Network planning services",
                GoodsCode = "81111706NPS01",
                MeasureUnit = "UN",
                UnitPrice = "20000000",
                Currency = "101",
                CommodityCategoryId = "81111706",
                HaveExciseTax = "102",
                StockPrewarning = "5",
            };

            goodsUpload.Add(stockItem);
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T130";

            string serializedRequest = JsonSerializer.Serialize(goodsUpload, new JsonSerializerOptions { IgnoreNullValues = true });
            Console.WriteLine("Serialized request: " + serializedRequest);
            byte[] serializedRequestBytes = Encoding.UTF8.GetBytes(serializedRequest);
            request.Data.Content = Convert.ToBase64String(EncryptionHelper.Encrypt(serializedRequestBytes, Convert.FromBase64String(File.ReadAllText(appConfig.SessionAESKey))));
            byte[] privateKey = Convert.FromBase64String(File.ReadAllText(appConfig.PrivateKey));
            using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsaCng = new RSACng(signingKey))
            {
                request.Data.Signature = Convert.ToBase64String(rsaCng.SignData(Encoding.UTF8.GetBytes(request.Data.Content), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
            }
            var response = (List<T130.Response>) SendRequest(request);
            return response;
        }

        public T109.Response UploadInvoice(T109.Request Invoice)
        {
            Request request = new Request(appConfig);
            request.GlobalInfo.InterfaceCode = "T109";
            Invoice.BasicInformation.DeviceNo = request.GlobalInfo.DeviceNo;
            Invoice.SellerDetails.Tin = request.GlobalInfo.TIN;
            string serializedInvoice = JsonSerializer.Serialize(Invoice, new JsonSerializerOptions { IgnoreNullValues = true });
            Console.WriteLine("Serialized Invoice: " + serializedInvoice);
            byte[] serializedRequestBytes = Encoding.UTF8.GetBytes(serializedInvoice);
            request.Data.Content = Convert.ToBase64String(EncryptionHelper.Encrypt(serializedRequestBytes, Convert.FromBase64String(File.ReadAllText(appConfig.SessionAESKey))));
            byte[] privateKey = Convert.FromBase64String(File.ReadAllText(appConfig.PrivateKey));
            using (CngKey signingKey = CngKey.Import(privateKey, CngKeyBlobFormat.Pkcs8PrivateBlob))
            using (RSACng rsaCng = new RSACng(signingKey))
            {
                request.Data.Signature = Convert.ToBase64String(rsaCng.SignData(Encoding.UTF8.GetBytes(request.Data.Content), HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1));
            }
            var response = (T109.Response) SendRequest(request);
            return response;
        }

        public T109.Response SendInvoice()
        {
            var result = UploadInvoice(CreateInvoice());
            return result;
        }

        T109.Request CreateInvoice()
        {
            var invoice = new T109.Request();

            invoice.SellerDetails.ReferenceNo = DateTime.Now.ToString("yyyyMMddHHmmss");

            invoice.BasicInformation.DeviceNo = appConfig.DeviceNo;
            invoice.BasicInformation.IssuedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            invoice.BasicInformation.Operator = "David Musinguzi";
            invoice.BasicInformation.Currency = "UGX";
            invoice.BasicInformation.OriInvoiceId = invoice.SellerDetails.ReferenceNo;
            invoice.BasicInformation.InvoiceType = "1";
            invoice.BasicInformation.InvoiceKind = "1";
            invoice.BasicInformation.DataSource = "103";
            invoice.BasicInformation.InvoiceIndustryCode = "101";

            invoice.BuyerDetails.BuyerCitizenship = "Ugandan";
            invoice.BuyerDetails.BuyerSector = "1";
            invoice.BuyerDetails.BuyerType = "1";

            T109.GoodsItem item = new T109.GoodsItem();
            item.Item = "Radio";
            item.ItemCode = "Radio";
            item.Quantity = "2";
            item.UnitOfMeasure = "103";
            item.UnitPrice = "500000.00";
            item.Total = "1000000.00";
            item.TaxRate = "0.18";
            item.Tax = "180000.00";
            item.OrderNumber = "0";
            item.DiscountFlag = "2";
            item.ExciseFlag = "2";
            item.DeemedFlag = "2";
            item.GoodsCategoryId = "43221704";
            item.GoodsCategoryName = "Radio core equipment";
            invoice.GoodsDetails.Add(item);

            T109.TaxDetail taxDetail = new T109.TaxDetail();
            taxDetail.TaxCategory = "Standard";
            taxDetail.GrossAmount = "1000000.00";
            taxDetail.TaxRate = "0.18";
            taxDetail.TaxAmount = "180000.00";
            taxDetail.NetAmount = "820000.00";
            taxDetail.TaxRateName = "Value Added Tax";
            invoice.TaxDetails.Add(taxDetail);

            invoice.Summary.ItemCount = "1";
            invoice.Summary.GrossAmount = "1000000";
            invoice.Summary.NetAmount = "820000";
            invoice.Summary.TaxAmount = "180000";
            invoice.Summary.ModeCode = "1";

            T109.Payment payment = new T109.Payment();
            payment.PaymentMode = "102";
            payment.PaymentAmount = "1000000.00";
            payment.OrderNumber = "0";
            invoice.PayWay.Add(payment);

            return invoice;
        }
    }
}
