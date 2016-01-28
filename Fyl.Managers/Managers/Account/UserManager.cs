using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using Fyl.Helpers;
using System.Security.Cryptography;
using Fyl.Library.Helpers;
using Fyl.Session;

namespace Fyl.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserManager(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public RegistrationResponseDto RegisterUser(RegistrationRequestDto dto)
        {
            var response = new RegistrationResponseDto()
            {
                EmailExists = true // check user repository
            };

            if (!response.EmailExists)
            {
                var authentication = _passwordHasher.HashPassword(dto.Password);

                try
                {
                    _userRepository.RegisterUser(dto, authentication);
                    response.Success = true;
                }
                catch (Exception)
                {
                    response.Success = false;
                }
            }

            return response;
        }

        public async Task<UserProfileSessionData> LoginUser(LoginDto dto)
        {
            //var profileData = await _accountRepository.LoginUser(dto);

            //return profileData;

            return new UserProfileSessionData();
        }
    }
}
