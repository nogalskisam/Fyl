using Fyl.Entities;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IFylEntities _entities;

        public AccountRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public async Task RegisterUser(RegisterDto dto)
        {
            var entity = await _entities.Users
                .AnyAsync(s => s.EmailAddress == dto.EmailAddress);

            if (!entity)
            {
                var newUser = new User()
                {
                    Firstname = dto.FirstName,
                    Lastname = dto.LastName,
                    ContactNumber = dto.ContactNumber,
                    EmailAddress = dto.EmailAddress,
                    DateOfBirth = dto.DateOfBirth,
                    Role = dto.Role
                };

                _entities.Users.Add(newUser);

                await _entities.SaveChangesAsync();
            }
            else
            {
                throw new Exception("A user with that email address already exists!");
            }
        }
    }
}
