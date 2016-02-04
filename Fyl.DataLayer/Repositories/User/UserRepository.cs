using Fyl.Entities;
using Fyl.Library.Dto;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IFylEntities _entities;

        public UserRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public async Task<UserDto> RegisterUser(RegistrationRequestDto dto, SaltedHashResult auth)
        {
            var user = new User()
            {
                EmailAddress = dto.EmailAddress,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                DateRegistered = DateTime.UtcNow,
                Authentication = new UserAuthentication()
                {
                    PasswordHash = auth.Hash,
                    PasswordSalt = auth.Salt
                },
                Role = dto.Role
            };

            _entities.Users.Add(user);

            await _entities.SaveChangesAsync();

            return user.ToDto();
        }

        public SessionDetailDto GetValidSession(Guid sessionId)
        {
            var session = _entities.Sessions
                .Include(s => s.User)
                .SingleOrDefault(s => s.SessionId == sessionId);

            if (session != null && session.ValidUntilUtc > DateTime.UtcNow)
            {
                return session.ToSessionDetailDto();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> EmailExists(string emailAddress)
        {
            bool exists = await _entities.Users
                .AnyAsync(a => a.EmailAddress.ToUpper().Equals(emailAddress.ToUpper()));

            return exists;
        }

        public async Task<LoginResponseDto> LoginUser(Guid userId, string ipAddress)
        {
            var user = await _entities.Users
                .SingleAsync(s => s.UserId == userId);

            var newSession = new Fyl.Entities.Session()
            {
                UserId = userId,
                ValidFromUtc = DateTime.UtcNow,
                ValidUntilUtc = DateTime.UtcNow.AddHours(1),
                IpAddress = ipAddress
            };

            _entities.Sessions.Add(newSession);
            await _entities.SaveChangesAsync();

            var result = new LoginResponseDto()
            {
                User = user.ToDto(),
                Session = newSession.ToDto(),
                IsSuccess = true
            };

            return result;
        }

        public async Task<UserAuthenticationDto> GetUserAuthentication(string email)
        {
            email = email.ToLower();

            var authentication = await _entities.UserAuthentications
                .SingleOrDefaultAsync(s => s.User.EmailAddress.ToLower() == email);

            var result = authentication != null ? authentication.ToDto() : null;

            return result;
        }
    }
}
