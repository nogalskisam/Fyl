using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public interface IUserManager
    {
        Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto);

        Task<LoginResponseDto> LoginUser(LoginRequestDto dto);

        SessionDetailDto GetValidSession(Guid sessionId);
    }
}
