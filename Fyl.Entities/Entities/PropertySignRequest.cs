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
    public class PropertySignRequest
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PropertySignRequestId { get; set; }

        public Guid PropertyId { get; set; }

        public Guid UserId { get; set; }

        public PropertyRequestStatusEnum Status { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime? DateAccepted { get; set; }
    }
}
