using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    [DataContract]
    public class LoginRequestDto
    {
        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string IpAddress { get; set; }
    }
}
