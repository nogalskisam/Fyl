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

        PropertyBasicDetailsDto GetPropertyDetails(Guid propertyId);
    }
}
