using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class SignRequestModel
    {
        public SignRequestModel()
        {
        }

        public SignRequestModel(SignRequestDetailsDto dto)
        {
            PropertySignRequestId = dto.PropertySignRequestId;
            PropertyId = dto.PropertyId;
            UserId = dto.UserId;
            Status = dto.Status;
            DateRequested = dto.DateRequested;
            DateAccepted = dto.DateResponded;
        }

        public Guid PropertySignRequestId { get; set; }

        public Guid PropertyId { get; set; }

        public Guid UserId { get; set; }

        public PropertyRequestStatusEnum Status { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime? DateAccepted { get; set; }
    }
}