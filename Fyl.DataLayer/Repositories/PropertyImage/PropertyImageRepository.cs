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
    public class PropertyImageRepository
    {
        private IFylEntities _entities;

        public PropertyImageRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public void AddPropertyImages(List<PropertyImageAddDto> images)
        {
            string path = @"C:\Fyl\Images\Properties\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var image in images)
            {
                var propertyImage = new PropertyImage()
                {
                    PropertyId = image.PropertyId,
                    Primary = image.Primary
                };

                _entities.PropertyImages.Add(propertyImage);
            }

            _entities.SaveChanges();
        }
    }
}
