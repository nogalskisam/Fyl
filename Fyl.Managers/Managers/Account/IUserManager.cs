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
        RegistrationResponseDto RegisterUser(RegistrationRequestDto dto);

        Task<UserProfileSessionData> LoginUser(LoginDto dto);
    }
}
