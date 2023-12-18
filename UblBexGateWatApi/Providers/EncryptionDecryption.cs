using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UblBexGateWatApi.Providers
{
    public static class EncryptionDecryption
    {
         private static string Key = "UblBexGateWay";
            public static string Encrypt(string plainText)
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                var res = Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(Key)));
                return res;
            }
            public static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
            {
                return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }
            public static string Decrypt(string encryptedText)
            {
                var encryptedBytes = Convert.FromBase64String(encryptedText);
                return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(Key)));
            }
            public static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
            {
                return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }


            public static string HashString(string text, string salt = "")
            {
                if (String.IsNullOrEmpty(text))
                {
                    return String.Empty;
                }

                // Uses SHA256 to create the hash
                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    // Convert the string to a byte array first, to be processed
                    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text + salt);
                    byte[] hashBytes = sha.ComputeHash(textBytes);

                    // Convert back to a string, removing the '-' that BitConverter adds
                    string hash = BitConverter
                        .ToString(hashBytes)
                        .Replace("-", String.Empty);

                    return hash;
                }
            }
            public static RijndaelManaged GetRijndaelManaged(String secretKey)
            {
                var keyBytes = new byte[16];
                var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
                Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
                return new RijndaelManaged
                {
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    KeySize = 128,
                    BlockSize = 128,
                    Key = keyBytes,
                    IV = keyBytes
                };
            }
        
    }
}