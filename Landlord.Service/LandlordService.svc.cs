using Fyl.DataLayer;
using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Managers;
using System;
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

        public LandlordService(IAddressRepository addressRepository, IUserRepository accountRepository, IUserManager userManager, IPropertyManager propertyManager, IPropertySignRequestManager propertySignRequestManager)
        {
            _addressRepository = addressRepository;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _propertyManager = propertyManager;
            _propertySignRequestManager = propertySignRequestManager;
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
    }
}
