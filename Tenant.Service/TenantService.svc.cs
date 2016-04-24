using Fyl.DataLayer;
using Fyl.DataLayer.Repositories;
using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Library.Enum;
using Fyl.Managers;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TenantService : ITenantService
    {
        //private ILog _logger;
        private IAddressRepository _addressRepository;
        private IUserRepository _accountRepository;
        private IUserManager _userManager;
        private IPropertyManager _propertyManager;
        private IPropertySignRequestManager _propertySignRequestManager;

        public TenantService(/*ILog logger,*/ IAddressRepository addressRepository, IUserRepository accountRepository, IUserManager userManager, IPropertyManager propertyManager, IPropertySignRequestManager propertySignRequestManager)
        {
            //_logger = logger;
            _addressRepository = addressRepository;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _propertyManager = propertyManager;
            _propertySignRequestManager = propertySignRequestManager;
        }

        public List<AddressDto> GetAllAddresses()
        {
            var dtos = _addressRepository.GetAllAddresses();

            return dtos;
        }

        public async Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto)
        {
            var result = await _userManager.RegisterUser(dto);

            return result;
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

        public PropertyListResponseDto GetAvailablePropertiesForList(PropertyListRequestDto request)
        {
            var result = _propertyManager.GetAvailablePropertiesForList(request);

            return result;
        }

        public PropertyBasicDetailsDto GetPropertyDetails(Guid propertyId)
        {
            var dto = _propertyManager.GetPropertyBasicDetails(propertyId);

            return dto;
        }

        public void AddNewPropertySignRequest(Guid propertyId, Guid userId)
        {
            _propertySignRequestManager.AddNewPropertySignRequest(propertyId, userId);
        }

        public PropertyRequestStatusEnum GetPropertySignRequestForIdAndUser(Guid propertyId, Guid userId)
        {
            var requestStatus = _propertySignRequestManager.GetPropertySignRequestForIdAndUser(propertyId, userId);

            return requestStatus;
        }

        public bool PropertySignRequestExists(Guid propertyId, Guid userId)
        {
            bool exists = _propertySignRequestManager.PropertySignRequestExists(propertyId, userId);

            return exists;
        }
    }
}
