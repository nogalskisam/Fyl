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
        private IUserManager _userManager;

        public LandlordService(IUserManager userManager)
        {
            _userManager = userManager;
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
