using Fyl.Entities;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private IFylEntities _entities;

        public PropertyRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public List<PropertyListItemDto> GetAvailablePropertiesForListItems(PropertyListRequestDto request)
        {
            var query = GetAvailablePropertiesQuery(request);

            var dtos = query.Select(s => new PropertyListItemDto()
            {
                PropertyId = s.PropertyId,
                Beds = s.Beds,
                Postcode = s.Address.Postcode,
                PropertyImageId = s.Images
                                .Where(w => w.PropertyId == s.PropertyId)
                                .Where(w => w.Primary)
                                .Select(w => w.PropertyImageId)
                                .FirstOrDefault()
            }).ToList();

            return dtos;
        }

        private IQueryable<Property> GetAvailablePropertiesQuery(PropertyListRequestDto request)
        {
            var query = _entities.Properties
                .Include(i => i.Address)
                .Include(i => i.Tenants)
                .Include(i => i.Images)
                .Where(p => p.Tenants.Count == 0);

            if (!string.IsNullOrWhiteSpace(request.PostCode))
            {
                query = query.Where(q => q.Address.Postcode.Contains(request.PostCode));
            }

            if (request.Beds != null)
            {
                query = query.Where(q => q.Beds == request.Beds);
            }

            return query;
        }

        public int GetAvailablePropertiesForListCount(PropertyListRequestDto request)
        {
            return GetAvailablePropertiesQuery(request).Count();
        }

        public PropertyDetailsDto GetPropertyDetails(Guid propertyId)
        {
            var property = _entities.Properties
                .Include(i => i.Address)
                .Include(i => i.Images)
                .Include(i => i.PropertyRatings)
                .Where(w => w.PropertyId == propertyId)
                .Select(t => new PropertyDetailsDto()
                {
                    PropertyId = t.PropertyId,
                    StartDate = t.StartDate,
                    Address1 = t.Address.Address1,
                    Area = t.Address.Area,
                    City = t.Address.City,
                    PostCode = t.Address.Postcode,
                    PropertyImageIds = t.Images
                        .Where(pi => pi.PropertyId == propertyId)
                        .Select(pi => pi.PropertyImageId)
                        .ToList(),
                    Beds = t.Beds
                })
                .FirstOrDefault();

            return property;
        }
    }
}
