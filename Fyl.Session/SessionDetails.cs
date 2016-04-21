using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public class SessionDetails : ISessionDetails
    {
        public UserDto User { get; set; }

        public bool IsAuthenticated { get { return this.User != null; } }
    }
}
