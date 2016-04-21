using Fyl.Entities;
using Fyl.Library.Dto;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class LandlordRepository : ILandlordRepository
    {
        private readonly IFylEntities _entities;

        public LandlordRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public UserDto Register(RegistrationRequestDto dto, SaltedHashResult auth)
        {
            var tenant = new Landlord()
            {
                LandlordUser = new User()
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
                }
            };

            _entities.Landlords.Add(tenant);
            _entities.SaveChanges();

            return tenant.LandlordUser.ToDto();
        }
    }
}
