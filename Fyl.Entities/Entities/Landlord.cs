using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class Landlord
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LandlordId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid UserId { get; set; }
    }
}
