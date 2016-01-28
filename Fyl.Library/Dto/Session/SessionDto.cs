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
    public class SessionDto
    {
        [DataMember]
        public Guid SessionId { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        [Required]
        public DateTime ValidFromUtc { get; set; }

        [DataMember]
        [Required]
        public DateTime ValidUntilUtc { get; set; }

        [DataMember]
        [StringLength(46)]
        public string IpAddress { get; set; }
    }
}
