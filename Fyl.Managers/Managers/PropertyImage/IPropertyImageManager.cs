using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public interface IPropertyImageManager
    {
        Guid AddPropertyImage(Guid propertyId);

        List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId);

        PropertyImageDetailDto GetPropertyImage(Guid propertyImageId);

        bool UpdatePropertyImage(PropertyImageDetailDto dto);
    }
}
