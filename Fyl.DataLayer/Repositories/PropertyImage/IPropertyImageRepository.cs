using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IPropertyImageRepository
    {
        Guid AddPropertyImage(Guid propertyId);

        List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId);
    }
}
