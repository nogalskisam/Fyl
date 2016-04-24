using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IPropertyRepository
    {
        List<PropertyListItemDto> GetAvailablePropertiesForListItems(PropertyListRequestDto request);

        int GetAvailablePropertiesForListCount(PropertyListRequestDto request);

        List<LandlordPropertyListItemDto> GetPropertiesForLandlordListItems(Guid userId);

        int GetPropertiesForLandlordListCount(Guid userId);

        PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId);

        Guid AddNewProperty(Guid userId, PropertyAddBasicDto dto);

        PropertyDetailedDto GetPropertyDetails(Guid propertyId);

        Guid EditProperty(Guid userId, PropertyAddBasicDto dto);

        PropertyDetailedDto GetPropertyForTenantUser(Guid userId);
    }
}
