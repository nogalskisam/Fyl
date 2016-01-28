using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public class SaltedHashResult
    {
        public byte[] Hash { get; set; }

        public byte[] Salt { get; set; }
    }
}
