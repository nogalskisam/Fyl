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
                .Include(i => i.SignRequests)
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
                .Include(i => i.Address)
                .Include(i => i.SignRequests)
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
                SignRequestCount = s.SignRequests.Count
            }).ToList();

            return dtos;
        }

        public int GetPropertiesForLandlordListCount(Guid userId)
        {
            return GetPropertiesForLandlordListQuery(userId).Count();
        }

        public PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId)
        {
            var property = _entities.Properties
                .Include(i => i.Address)
                .Include(i => i.Images)
                .Include(i => i.Ratings)
                .Include(i => i.SignRequests)
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
                    Deposit = t.Deposit,
                    SignRequestCount = t.SignRequests.Count
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

        public Guid EditProperty(Guid userId, PropertyAddBasicDto dto)
        {
            var property = _entities.Properties
                .Where(w => w.PropertyId == dto.PropertyId.Value)
                .SingleOrDefault();

            if (property != null)
            {
                property.PropertyId = dto.PropertyId.Value;
                property.Rent = dto.Rent;
                property.StartDate = dto.StartTime;
                property.Deposit = dto.Deposit;
                property.Beds = dto.Beds;
                property.AddressId = dto.AddressId.Value;
            }

            _entities.SaveChanges();

            return property.PropertyId;
        }

        public PropertyDetailedDto GetPropertyDetails(Guid propertyId)
        {
            var property = _entities.Properties
                .Include(i => i.Address)
                .Include(i => i.Images)
                .Include(i => i.Ratings)
                .Include(i => i.SignRequests)
                .Where(w => w.PropertyId == propertyId)
                .Select(t => new PropertyDetailedDto()
                {
                    PropertyId = t.PropertyId,
                    Beds = t.Beds,
                    Rent = t.Rent,
                    Deposit = t.Deposit,
                    StartDate = t.StartDate,
                    HouseName = t.Address.HouseName,
                    AddressId = t.Address.AddressId,
                    Address1 = t.Address.Address1,
                    Address2 = t.Address.Address2,
                    Area = t.Address.Area,
                    City = t.Address.City,
                    County = t.Address.County,
                    Country = t.Address.Country,
                    PostCode = t.Address.Postcode
                })
                .FirstOrDefault();

            return property;
        }
    }
}
