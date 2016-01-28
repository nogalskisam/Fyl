using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public interface IPasswordHasher
    {
        SaltedHashResult HashPassword(string password);

        bool PasswordMatches(string password, byte[] salt, byte[] expectedHash);
    }
}
