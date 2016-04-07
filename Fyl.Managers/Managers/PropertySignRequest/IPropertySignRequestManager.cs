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
    }
}
