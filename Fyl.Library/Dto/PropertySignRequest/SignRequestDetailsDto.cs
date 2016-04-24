using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class SignRequestDetailsDto
    {
        public Guid PropertySignRequestId { get; set; }

        public Guid PropertyId { get; set; }

        public Guid UserId { get; set; }

        public PropertyRequestStatusEnum Status { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime? DateResponded { get; set; }
    }
}
