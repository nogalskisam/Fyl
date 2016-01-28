using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int SALT_SIZE = 32;

        public SaltedHashResult HashPassword(string password)
        {
            var saltBytes = new byte[SALT_SIZE];
            new RNGCryptoServiceProvider().GetNonZeroBytes(saltBytes);

            var result = HashPlainTextPasswordAndSalt(password, saltBytes);

            return new SaltedHashResult()
            {
                Salt = saltBytes,
                Hash = result
            };
        }

        public bool PasswordMatches(string password, byte[] salt, byte[] expectedHash)
        {
            byte[] hashResult = HashPlainTextPasswordAndSalt(password, salt);

            return hashResult.SequenceEqual(expectedHash);
        }

        
        private byte[] HashPlainTextPasswordAndSalt(string password, byte[] saltBytes)
        {
            byte[] plainPasswordBytes = Encoding.UTF8.GetBytes(password);

            byte[] passwordAndSaltBytes = new byte[plainPasswordBytes.Length + saltBytes.Length];

            plainPasswordBytes.CopyTo(passwordAndSaltBytes, 0);

            saltBytes.CopyTo(passwordAndSaltBytes, plainPasswordBytes.Length);

            var hashAlgorithm = new SHA256Managed();
            var hashedResult = hashAlgorithm.ComputeHash(passwordAndSaltBytes);

            return hashedResult;
        }
    }
}
