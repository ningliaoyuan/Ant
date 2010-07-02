using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Ant.Models.Common
{
    public static class Encryptor
    {
        private static byte[] KEY = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6,
            7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2
        };
        private static byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6 };

        public static string Encrypt(string encryptString)
        {
            try
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);

                Rijndael cryptor = Rijndael.Create();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, cryptor.CreateEncryptor(KEY, IV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                throw;
            }
        }

        public static string Decrypt(string decryptString)
        {
            try
            {
                byte[] inputByteArray = Convert.FromBase64String(decryptString);

                Rijndael cryptor = Rijndael.Create();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, cryptor.CreateDecryptor(KEY, IV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                throw;
            }
        }
    }
}