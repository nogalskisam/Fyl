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

        private IQueryable<Property> GetPropertiesForLandlordListQuery(Guid userId)
        {
            var query = _entities.Properties
                .Where(w => w.LandlordId == userId);

            return query;
        }

        public List<LandlordPropertyListItemDto> GetPropertiesForLandlordListItems(Guid userId)
        {
            var query = GetPropertiesForLandlordListQuery(userId);

            var dtos = query.Select(s => new LandlordPropertyListItemDto()
            {
                PropertyId = s.PropertyId,
                Address = new AddressDto()
                {
                    AddressId = s.AddressId,
                    HouseName = s.Address.HouseName,
                    Address1 = s.Address.Address1,
                    Address2 = s.Address.Address2,
                    Area = s.Address.Area,
                    City = s.Address.City,
                    Country = s.Address.Country,
                    County = s.Address.County,
                    Postcode = s.Address.Postcode
                },
                Beds = s.Beds,
                Postcode = s.Address.Postcode,
            }).ToList();

            return dtos;
        }

        public int GetPropertiesForLandlordListCount(Guid userId)
        {
            return GetPropertiesForLandlordListQuery(userId).Count();
        }

        public PropertyBasicDetailsDto GetPropertyDetails(Guid propertyId)
        {
            var property = _entities.Properties
                .Include(i => i.Address)
                .Include(i => i.Images)
                .Include(i => i.PropertyRatings)
                .Where(w => w.PropertyId == propertyId)
                .Select(t => new PropertyBasicDetailsDto()
                {
                    PropertyId = t.PropertyId,
                    StartDate = t.StartDate,
                    Address1 = t.Address.Address1,
                    Area = t.Address.Area,
                    City = t.Address.City,
                    PostCode = t.Address.Postcode,
                    PropertyImageIds = t.Images
                        .Where(pi => pi.PropertyId == propertyId)
                        .Where(pi => !pi.Inactive)
                        .Select(pi => pi.PropertyImageId)
                        .ToList(),
                    Beds = t.Beds,
                    Rent = t.Rent,
                    Deposit = t.Deposit
                })
                .FirstOrDefault();

            return property;
        }

        public Guid AddNewProperty(Guid userId, PropertyAddBasicDto dto)
        {
            var property = new Property()
            {
                LandlordId = userId,
                Beds = dto.Beds,
                StartDate = dto.StartTime,
                Deposit = dto.Deposit,
                Rent = dto.Rent,
                AddressId = dto.AddressId ?? dto.AddressId.Value
            };

            _entities.Properties.Add(property);
            _entities.SaveChanges();

            return property.PropertyId;
        }
    }
}
