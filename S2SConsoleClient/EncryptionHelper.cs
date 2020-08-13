using System;
using System.Security.Cryptography;
using System.Text;

namespace S2SConsoleClient
{
    public static class EncryptionHelper
    {
        private static AesCryptoServiceProvider CreateProvider(byte[] key)
        {
            return new AesCryptoServiceProvider
            {
                Key = key,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.ECB
            };
        }

        public static byte[] Decrypt(byte[] data, byte[] key = null)
        {
            using (AesCryptoServiceProvider csp = CreateProvider(key))
            {
                ICryptoTransform decrypter = csp.CreateDecryptor();
                return decrypter.TransformFinalBlock(data, 0, data.Length);
            }
        }

        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            using (AesCryptoServiceProvider csp = CreateProvider(key))
            {
                ICryptoTransform encrypter = csp.CreateEncryptor();
                return encrypter.TransformFinalBlock(data, 0, data.Length);
            }
        }
    }
}
