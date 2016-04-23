using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public class PropertyImageManager : IPropertyImageManager
    {
        private IPropertyImageRepository _propertyImageRepository;

        public PropertyImageManager(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }

        public Guid AddPropertyImage(Guid propertyId)
        {
            return _propertyImageRepository.AddPropertyImage(propertyId);
        }

        public List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId)
        {
            var dtos = _propertyImageRepository.GetPropertyImagesForProperty(propertyId);

            return dtos;
        }

        public PropertyImageDetailDto GetPropertyImage(Guid propertyImageId)
        {
            var dto = _propertyImageRepository.GetPropertyImage(propertyImageId);

            return dto;
        }

        public bool UpdatePropertyImage(PropertyImageDetailDto dto)
        {
            var edited = _propertyImageRepository.UpdatePropertyImage(dto);

            return edited;
        }
    }
}
