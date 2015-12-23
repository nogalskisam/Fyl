using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class PasswordAuthorisation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PasswordAuthorisationId { get; set; }

        public string Hash { get; set; }

        public string Salt { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}
