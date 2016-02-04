using Fyl.Library.Dto;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> RegisterUser(RegistrationRequestDto dto, SaltedHashResult auth);

        SessionDetailDto GetValidSession(Guid sessionId);

        Task<bool> EmailExists(string emailAddress);

        Task<LoginResponseDto> LoginUser(Guid userId, string ipAddress);

        Task<UserAuthenticationDto> GetUserAuthentication(string email);
    }
}
