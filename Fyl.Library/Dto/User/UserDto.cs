using Fyl.Library.Enum;
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
    public class UserDto
    {
        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public RoleEnum Role { get; set; }
    }
}
