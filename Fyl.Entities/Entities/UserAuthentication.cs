using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class UserAuthentication
    {
        [Key]
        public Guid UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [MaxLength(32)]
        public byte[] PasswordHash { get; set; }

        [MaxLength(32)]
        public byte[] PasswordSalt { get; set; }

        public UserAuthenticationDto ToDto()
        {
            return new UserAuthenticationDto()
            {
                UserId = this.UserId,
                PasswordHash = this.PasswordHash,
                PasswordSalt = this.PasswordSalt
            };
        }
    }
}
