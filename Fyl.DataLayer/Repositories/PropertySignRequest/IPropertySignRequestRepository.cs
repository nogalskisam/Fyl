using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IPropertySignRequestRepository
    {
        void AddNewPropertySignRequest(Guid propertyId, Guid userId);

        PropertyRequestStatusEnum GetPropertySignRequestStatusForIdAndUser(Guid propertyId, Guid userId);

        bool PropertySignRequestExists(Guid propertyId, Guid userId);
    }
}
