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

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string ContactNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateRegistered { get; set; }

        public RoleEnum Role { get; set; }

        public Guid PasswordAuthorisationId { get; set; }

        [ForeignKey("PasswordAuthorisationId")]
        public PasswordAuthorisation PasswordAuthorisation { get; set; }
    }
}
