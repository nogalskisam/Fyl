using Fyl.Entities;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class PropertySignRequestRepository : IPropertySignRequestRepository
    {
        private IFylEntities _entities;

        public PropertySignRequestRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public void AddNewPropertySignRequest(Guid propertyId, Guid userId)
        {
            var entity = new PropertySignRequest()
            {
                PropertyId = propertyId,
                UserId = userId,
                DateRequested = DateTime.UtcNow,
                Status = PropertyRequestStatusEnum.Pending
            };

            _entities.PropertySignRequests.Add(entity);
            _entities.SaveChanges();
        }

        public PropertyRequestStatusEnum GetPropertySignRequestStatusForIdAndUser(Guid propertyId, Guid userId)
        {
            var status = _entities.PropertySignRequests
                            .Where(psr => psr.PropertyId == propertyId)
                            .Where(psr => psr.UserId == userId)
                            .Select(s => s.Status)
                            .FirstOrDefault();

            return status;
        }

        public bool PropertySignRequestExists(Guid propertyId, Guid userId)
        {
            var exists = _entities.PropertySignRequests
                            .Where(psr => psr.PropertyId == propertyId)
                            .Where(psr => psr.UserId == userId)
                            .Any();

            return exists;
        }
    }
}
