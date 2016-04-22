using Fyl.Entities;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private IFylEntities _entities;

        public PropertyImageRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public Guid AddPropertyImage(Guid propertyId)
        {
            var entity = new PropertyImage()
            {
                PropertyId = propertyId
            };

            _entities.PropertyImages.Add(entity);
            _entities.SaveChanges();

            return entity.PropertyImageId;
        }

        public List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId)
        {
            var dtos = _entities.PropertyImages
                .Where(w => w.PropertyId == propertyId)
                .Where(w => !w.Inactive)
                .Select(s => new PropertyImageDto()
                {
                    PropertyImageId = s.PropertyImageId,
                    PropertyId = s.PropertyId
                })
                .ToList();

            return dtos;
        }
    }
}
