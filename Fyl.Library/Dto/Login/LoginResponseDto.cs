using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }

        public SessionDto Session { get; set; }

        public bool IsSuccess { get; set; }
    }
}
