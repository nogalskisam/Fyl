using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class Property
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropertyId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        public Guid AddressId { get; set; }

        public int Beds { get; set; }

        [ForeignKey("LandlordId")]
        public virtual Landlord Landlord { get; set; }

        public Guid LandlordId { get; set; }

        public virtual List<Tenant> Tenants { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Available { get; set; }
    }
}
