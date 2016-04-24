using Fyl.DataLayer;
using Fyl.DataLayer.Repositories;
using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Managers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Landlord.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LandlordService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LandlordService.svc or LandlordService.svc.cs at the Solution Explorer and start debugging.
    public class LandlordService : ILandlordService
    {
        private IAddressRepository _addressRepository;
        private IUserRepository _accountRepository;
        private IUserManager _userManager;
        private IPropertyManager _propertyManager;
        private IPropertySignRequestManager _propertySignRequestManager;
        private IPropertyImageManager _propertyImageManager;

        public LandlordService(IAddressRepository addressRepository, IUserRepository accountRepository, IUserManager userManager, IPropertyManager propertyManager, IPropertySignRequestManager propertySignRequestManager, IPropertyImageManager propertyImageManager)
        {
            _addressRepository = addressRepository;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _propertyManager = propertyManager;
            _propertySignRequestManager = propertySignRequestManager;
            _propertyImageManager = propertyImageManager;
        }

        public async Task<LoginResponseDto> LoginUser(LoginRequestDto dto)
        {
            var profileData = await _userManager.LoginUser(dto);

            return profileData;
        }

        public SessionDetailDto GetValidSession(Guid sessionId)
        {
            return _userManager.GetValidSession(sessionId);
        }

        public Guid AddProperty(Guid userId, PropertyAddEditDto dto)
        {
            var propertyId = _propertyManager.AddProperty(userId, dto);

            return propertyId;
        }

        public async Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto)
        {
            var result = await _userManager.RegisterUser(dto);

            return result;
        }

        public LandlordPropertyListResponseDto GetPropertiesForLandlordList(Guid userId)
        {
            var dtos = _propertyManager.GetPropertiesForLandlordList(userId);

            return dtos;
        }
        
        public PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId)
        {
            var dto = _propertyManager.GetPropertyBasicDetails(propertyId);

            return dto;
        }

        public List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId)
        {
            var dtos = _propertyImageManager.GetPropertyImagesForProperty(propertyId);

            return dtos;
        }

        public Guid AddPropertyImage(Guid propertyId)
        {
            return _propertyImageManager.AddPropertyImage(propertyId);
        }

        public PropertyImageDetailDto GetPropertyImage(Guid propertyImageId)
        {
            var dto = _propertyImageManager.GetPropertyImage(propertyImageId);

            return dto;
        }

        public bool UpdatePropertyImage(PropertyImageDetailDto dto)
        {
            var edited = _propertyImageManager.UpdatePropertyImage(dto);

            return edited;
        }

        public List<SignRequestDetailsDto> GetPropertySignRequestsForPropertyId(Guid propertyId)
        {
            var dtos = _propertySignRequestManager.GetPropertySignRequestsForPropertyId(propertyId);

            return dtos;
        }

        public bool SetPropertySignRequest(Guid propertySignRequestId, Guid propertyId, Guid userId, bool accepted)
        {
            var result = _propertySignRequestManager.SetPropertySignRequest(propertySignRequestId, propertyId, userId, accepted);

            return result;
        }

        public PropertyDetailedDto GetPropertyDetails(Guid propertyId)
        {
            var dto = _propertyManager.GetPropertyDetails(propertyId);

            return dto;
        }

        public Guid EditProperty(Guid userId, PropertyAddEditDto dto)
        {
            var propertyId = _propertyManager.EditProperty(userId, dto);

            return propertyId;
        }
    }
}
