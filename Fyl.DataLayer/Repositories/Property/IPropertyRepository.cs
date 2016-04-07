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

        PropertyBasicDetailsDto GetPropertyDetails(Guid propertyId);
    }
}
