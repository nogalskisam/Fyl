using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Helpers
{
    public class HashResult
    {
        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }
    }

    public class Encryption
    {
        private const string fylSalt = @"as9fg0,D4GkjM,£xaLOo#*aGbFyl-L0B";
        private const int salt = 32;
        private const int hash = 32;
        private const int iterations = 10000;

        //public string Encrypt(string password)
        //{
        //    using (var encryption = new Rfc2898DeriveBytes("test123" + fylSalt, salt, iterations))
        //    {
        //        byte[] hash = encryption.GetBytes(32);
        //        byte[] salt = encryption.Salt;

        //        var test = new HashResult
        //        {
        //            Hash = hash,
        //            Salt = salt
        //        };

        //        var str = Convert.ToBase64String(hash);
        //    }
        //}
    }
}
