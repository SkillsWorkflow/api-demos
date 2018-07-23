using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TimesheetAndJobsExtractionTool.Core.Helpers
{
    class EncryptionUtilityHelper
    {
        public static string Encrypt(string dataToEncrypt, string key)
        {
            var encryptedData="";
            var clearBytes = Encoding.Unicode.GetBytes(dataToEncrypt);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(key, Encoding.Unicode.GetBytes("Skills"));
                if (encryptor == null) return encryptedData;
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptedData = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptedData;
        }
    }
}
