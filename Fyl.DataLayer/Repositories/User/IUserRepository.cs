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
        UserDto RegisterUser(RegistrationRequestDto dto, SaltedHashResult auth);

        //Task<Guid> AddPasswordAuthorisation(string password);

        //Task<UserProfileSessionData> LoginUser(LoginDto dto);
    }
}
