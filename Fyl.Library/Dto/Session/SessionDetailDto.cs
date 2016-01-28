using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    [DataContract]
    public class SessionDetailDto
    {
        [DataMember]
        public Guid SessionId { get; set; }

        [DataMember]
        public UserDto User { get; set; }

        [DataMember]
        public DateTime ValidFromUtc { get; set; }

        [DataMember]
        public DateTime ValidUntilUtc { get; set; }

        [DataMember]
        public string IpAddress { get; set; }
    }
}
