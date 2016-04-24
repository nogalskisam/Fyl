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
    public class TenantRepository : ITenantRepository
    {
        private readonly IFylEntities _entities;

        public TenantRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public UserDto Register(RegistrationRequestDto dto, SaltedHashResult auth)
        {
            var tenant = new Tenant()
            {
                TenantUser = new User()
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

            _entities.Tenants.Add(tenant);
            _entities.SaveChanges();

            return tenant.TenantUser.ToDto();
        }

        public void AssignTenantToProperty(Guid userId, Guid propertyId)
        {
            var entity = _entities.Tenants
                .Where(w => w.TenantId == userId)
                .SingleOrDefault();

            if (!entity.PropertyId.HasValue || (entity.PropertyId.HasValue && entity.PropertyId.Value != propertyId))
            {
                entity.PropertyId = propertyId;

                _entities.SaveChanges();
            }
        }
    }
}
