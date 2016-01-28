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

        public UserDto RegisterUser(RegistrationRequestDto dto, SaltedHashResult auth)
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
                }
            };

            _entities.Users.Add(user);

            _entities.SaveChanges();

            return user.ToDto();
        }

        //public async Task RegisterUser(RegisterDto dto)
        //{
        //    var entity = await _entities.Users
        //        .AnyAsync(s => s.EmailAddress == dto.EmailAddress);

        //    if (!entity)
        //    {
        //        var newUser = new User()
        //        {
        //            Firstname = dto.FirstName,
        //            Lastname = dto.LastName,
        //            ContactNumber = dto.ContactNumber,
        //            EmailAddress = dto.EmailAddress,
        //            DateOfBirth = dto.DateOfBirth,
        //            Role = dto.Role,
        //            PasswordAuthorisationId = dto.PasswordAuthorisationId.Value,
        //            DateRegistered = DateTime.UtcNow
        //        };

        //        _entities.Users.Add(newUser);

        //        await _entities.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new Exception("A user with that email address already exists!");
        //    }
        //}

        //public async Task<Guid> AddPasswordAuthorisation(string password)
        //{
        //    var newPassword = new PasswordAuthorisation()
        //    {
        //        Hash = password,
        //        ExpiryDate = DateTime.UtcNow.AddYears(1)
        //    };

        //    _entities.PasswordAuthorisations.Add(newPassword);
        //    await _entities.SaveChangesAsync();

        //    return newPassword.PasswordAuthorisationId;
        //}
        
        //public async Task<UserProfileSessionData> LoginUser(LoginDto dto)
        //{
        //    UserProfileSessionData profileData = new UserProfileSessionData();

        //    var entity = await _entities.Users
        //        .Where(u => u.EmailAddress == dto.EmailAddress)
        //        .Where(u => u.PasswordAuthorisation.Hash == dto.Password)
        //        .Where(u => u.PasswordAuthorisation.ExpiryDate > DateTime.UtcNow)
        //        .SingleOrDefaultAsync();

        //    if (entity != null)
        //    {
        //        profileData.UserId = entity.UserId;
        //        profileData.EmailAddress = entity.EmailAddress;
        //        profileData.FirstName = entity.Firstname;
        //        profileData.LastName = entity.Lastname;
        //        profileData.Role = entity.Role;
        //    }

        //    return profileData;
        //}
    }
}
