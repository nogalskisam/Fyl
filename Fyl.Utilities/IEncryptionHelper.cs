using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Utilities
{
    public interface IEncryptionHelper
    {
        string Encrypt(string message, string password);

        string Decrypt(string message, string password);
    }
}
