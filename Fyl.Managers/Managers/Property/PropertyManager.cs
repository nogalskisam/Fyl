using Fyl.DataLayer;
using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IAddressRepository _addressRepository;

        public PropertyManager(IPropertyRepository propertyRepository, IAddressRepository addressRepository)
        {
            _propertyRepository = propertyRepository;
            _addressRepository = addressRepository;
        }

        public PropertyListResponseDto GetAvailablePropertiesForList(PropertyListRequestDto request)
        {
            var items = _propertyRepository.GetAvailablePropertiesForListItems(request);
            var count = _propertyRepository.GetAvailablePropertiesForListCount(request);

            var result = new PropertyListResponseDto()
            {
                Items = items,
                Count = count
            };

            return result;
        }

        public LandlordPropertyListResponseDto GetPropertiesForLandlordList(Guid userId)
        {
            var items = _propertyRepository.GetPropertiesForLandlordListItems(userId);
            var count = _propertyRepository.GetPropertiesForLandlordListCount(userId);

            var result = new LandlordPropertyListResponseDto()
            {
                Items = items,
                Count = count
            };

            return result;
        }

        public PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId)
        {
            var dto = _propertyRepository.GetPropertyBasicDetails(propertyId);

            return dto;
        }

        public Guid AddProperty(Guid userId, PropertyAddEditDto dto)
        {
            var addressId = _addressRepository.AddAddress(dto.Address);

            dto.Property.AddressId = addressId;

            var propertyId = _propertyRepository.AddNewProperty(userId, dto.Property);

            return propertyId;
        }

        public Guid EditProperty(Guid userId, PropertyAddEditDto dto)
        {
            var addressId = _addressRepository.EditAddress(dto.Address);

            dto.Property.AddressId = addressId;

            var propertyId = _propertyRepository.EditProperty(userId, dto.Property);

            return propertyId;
        }

        public PropertyDetailedDto GetPropertyDetails(Guid propertyId)
        {
            var dto = _propertyRepository.GetPropertyDetails(propertyId);

            return dto;
        }

        public PropertyDetailedDto GetPropertyForTenantUser(Guid userId)
        {
            var dto = _propertyRepository.GetPropertyForTenantUser(userId);

            return dto;
        }
    }
}
