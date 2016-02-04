using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Utilities
{
    public class EncryptionHelper : IEncryptionHelper
    {
        static readonly byte[] SALT_BYTES = Encoding.UTF8.GetBytes("26mE8Wi64V3r5s60CY");
        static readonly byte[] INITIALISATION_VECTOR = Encoding.UTF8.GetBytes("c499Loo10O1pjPF8Vq");

        public string Encrypt(string plainText, string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(password, SALT_BYTES).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, INITIALISATION_VECTOR);

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }

                memoryStream.Close();
            }

            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string encryptedText, string password)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);

            byte[] keyBytes = new Rfc2898DeriveBytes(password, SALT_BYTES).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, INITIALISATION_VECTOR);
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();

            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
