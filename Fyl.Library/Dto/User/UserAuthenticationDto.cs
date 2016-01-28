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
    public class UserAuthenticationDto
    {
        [DataMember]
        public Guid UserId { get; set; }

        [MaxLength(32)]
        [DataMember]
        public byte[] PasswordHash { get; set; }

        [MaxLength(32)]
        [DataMember]
        public byte[] PasswordSalt { get; set; }
    }
}
