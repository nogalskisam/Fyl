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
        [ForeignKey("LandlordId")]
        public virtual User LandlordUser { get; set; }

        [Key]
        public Guid LandlordId { get; set; }

        public virtual List<Property> Properties { get; set; }

    }
}
