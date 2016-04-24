using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public interface IPropertyManager
    {
        PropertyListResponseDto GetAvailablePropertiesForList(PropertyListRequestDto request);

        LandlordPropertyListResponseDto GetPropertiesForLandlordList(Guid userId);

        PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId);

        Guid AddProperty(Guid userId, PropertyAddEditDto dto);

        Guid EditProperty(Guid userId, PropertyAddEditDto dto);

        PropertyDetailedDto GetPropertyDetails(Guid propertyId);
    }
}
