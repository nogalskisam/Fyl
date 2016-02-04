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

        public async Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto)
        {
            var response = new RegistrationResponseDto()
            {
                EmailExists = await _userRepository.EmailExists(dto.EmailAddress) // check user repository
            };

            if (!response.EmailExists)
            {
                var authentication = _passwordHasher.HashPassword(dto.Password);

                try
                {
                    await _userRepository.RegisterUser(dto, authentication);
                    response.Success = true;
                }
                catch (Exception)
                {
                    response.Success = false;
                }
            }

            return response;
        }

        public async Task<LoginResponseDto> LoginUser(LoginRequestDto dto)
        {
            UserAuthenticationDto auth = await _userRepository.GetUserAuthentication(dto.EmailAddress);
            
            if (auth == null)
            {
                return new LoginResponseDto() { IsSuccess = false };
            }

            bool credentialsValid = _passwordHasher.PasswordMatches(dto.Password, auth.PasswordSalt, auth.PasswordHash);

            if (!credentialsValid)
            {
                return new LoginResponseDto() { IsSuccess = false };
            }
            else
            {
                var response = await _userRepository.LoginUser(auth.UserId, dto.IpAddress);

                return response;
            }
        }

        public SessionDetailDto GetValidSession(Guid sessionId)
        {
            return _userRepository.GetValidSession(sessionId);
        }
    }
}
