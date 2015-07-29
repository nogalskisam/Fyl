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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TenantId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public Guid UserId { get; set; }
    }
}
