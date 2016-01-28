using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public virtual List<Session> Sessions { get; set; }

        public virtual UserAuthentication Authentication { get; set; }

        [Required, StringLength(256)]
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public RoleEnum Role { get; set; }

        public DateTime DateRegistered { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                UserId = this.UserId,
                EmailAddress = this.EmailAddress,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Role = this.Role
            };
        }
    }
}
