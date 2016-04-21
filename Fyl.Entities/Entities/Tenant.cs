using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class Tenant
    {
        [Key]
        public Guid TenantId { get; set; }

        [ForeignKey("TenantId")]
        public virtual User TenantUser { get; set; }

        public Guid? PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }

    }
}
