using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public interface IPropertySignRequestManager
    {
        void AddNewPropertySignRequest(Guid propertyId, Guid userId);

        PropertyRequestStatusEnum GetPropertySignRequestForIdAndUser(Guid propertyId, Guid userId);

        bool PropertySignRequestExists(Guid propertyId, Guid userId);

        List<SignRequestDetailsDto> GetPropertySignRequestsForPropertyId(Guid propertyId);

        bool SetPropertySignRequest(Guid propertySignRequestId, Guid propertyId, Guid userId, bool accepted);
    }
}
