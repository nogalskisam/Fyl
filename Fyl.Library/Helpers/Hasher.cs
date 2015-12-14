using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Helpers
{
    public class Hasher : IHasher
    {
        private const string fylSalt = @"as9fg0,D4GkjM,£xaLOo#*aGbFyl-L0B";

        private const int hashSize = 32;
        private const int saltSize = 32;
        private const int iterations = 10000;

        public class HashResult
        {
            public byte[] Salt { get; set; }
            public byte[] Hash { get; set; }
        }

        public HashResult CreatePasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                //exception
            }

            using (var encryption = new Rfc2898DeriveBytes(password + fylSalt, saltSize, iterations))
            {
                byte[] hash = encryption.GetBytes(hashSize);
                byte[] salt = encryption.Salt;

                return new HashResult
                {
                    Hash = hash,
                    Salt = salt
                };
            }
        }

        public bool HashMatches(string password, byte[] salt, byte[] expectedhash)
        {
            var encryption = new Rfc2898DeriveBytes(password + fylSalt, salt, iterations);
            byte[] hash = encryption.GetBytes(hashSize);

            bool match = expectedhash.SequenceEqual(hash);
            return match;
        }
    }

    public interface IHasher
    {
        Hasher.HashResult CreatePasswordHash(string password);

        bool HashMatches(string password, byte[] salt, byte[] expectedHash);
    }
}
