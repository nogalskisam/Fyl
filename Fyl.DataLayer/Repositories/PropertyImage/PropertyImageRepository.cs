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

        public PropertyImageDetailDto GetPropertyImage(Guid propertyImageId)
        {
            var dto = _entities.PropertyImages
                .Where(w => w.PropertyImageId == propertyImageId)
                .Select(s => new PropertyImageDetailDto()
                {
                    PropertyImageId = s.PropertyImageId,
                    PropertyId = s.PropertyId,
                    Primary = s.Primary,
                    Inactive = s.Inactive
                })
                .SingleOrDefault();

            return dto;
        }

        public bool UpdatePropertyImage(PropertyImageDetailDto dto)
        {
            var entity = _entities.PropertyImages
                .Where(w => w.PropertyImageId == dto.PropertyImageId)
                .SingleOrDefault();

            var oldPrimary = _entities.PropertyImages
                .Where(w => w.PropertyId == dto.PropertyId)
                .Where(w => w.Primary)
                .SingleOrDefault();

            bool edited = false;

            if (entity != null)
            {
                if (oldPrimary != null && dto.Primary)
                {
                    oldPrimary.Primary = false;

                    //_entities.SetModified(oldPrimary);
                }

                entity.Primary = dto.Primary;
                entity.Inactive = dto.Inactive;

                //_entities.SetModified(entity);
                _entities.SaveChanges();

                edited = true;
            }

            return edited;
        }
    }
}
