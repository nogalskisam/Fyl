using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Session
{
    public interface ISessionDetails
    {
        bool IsAuthenticated { get; }

        UserDto User { get; }
    }
}
