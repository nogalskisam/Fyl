using Fyl.Entities;
using Fyl.Library.Dto;
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

        public List<SignRequestDetailsDto> GetPropertySignRequestsForPropertyId(Guid propertyId)
        {
            var dtos = _entities.PropertySignRequests
                .Where(w => w.PropertyId == propertyId)
                .Select(s => new SignRequestDetailsDto()
                {
                    PropertySignRequestId = s.PropertySignRequestId,
                    PropertyId = s.PropertyId,
                    UserId = s.UserId,
                    Status = s.Status,
                    DateRequested = s.DateRequested,
                    DateResponded = s.DateResponded
                })
                .ToList();

            return dtos;
        }

        public bool SetPropertySignRequestAsDeclined(Guid propertySignRequestId)
        {
            var entity = _entities.PropertySignRequests
                .Where(w => w.PropertySignRequestId == propertySignRequestId)
                .SingleOrDefault();

            var set = false;

            if (entity != null)
            {
                entity.Status = PropertyRequestStatusEnum.Declined;
                entity.DateResponded = DateTime.UtcNow;

                _entities.SaveChanges();

                set = true;
            }

            return set;
        }

        public bool SetPropertySignRequestAsAccepted(Guid propertySignRequestId, Guid propertyId)
        {
            var entities = _entities.PropertySignRequests
                .Where(w => w.PropertyId == propertyId)
                .ToList();

            bool set = false;

            if (entities.Any(w => w.PropertyId == propertyId))
            {
                entities.ForEach(f => f.Status = PropertyRequestStatusEnum.Declined);
                entities.ForEach(f => f.DateResponded = DateTime.UtcNow);

                var entity = entities
                    .Where(w => w.PropertySignRequestId == propertySignRequestId)
                    .SingleOrDefault();

                if (entity != null)
                {
                    entity.Status = PropertyRequestStatusEnum.Accepted;
                    entity.DateResponded = DateTime.UtcNow;
                }

                set = true;

                _entities.SaveChanges();
            }

            return set;

        }
    }
}
