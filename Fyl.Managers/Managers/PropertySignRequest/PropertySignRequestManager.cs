﻿using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public class PropertySignRequestManager : IPropertySignRequestManager
    {
        private IPropertySignRequestRepository _repository;

        public PropertySignRequestManager(IPropertySignRequestRepository repository)
        {
            _repository = repository;
        }

        public void AddNewPropertySignRequest(Guid propertyId, Guid userId)
        {
            var exists = _repository.PropertySignRequestExists(propertyId, userId);

            if (!exists)
            {
                _repository.AddNewPropertySignRequest(propertyId, userId);
            }
        }

        public PropertyRequestStatusEnum GetPropertySignRequestForIdAndUser(Guid propertyId, Guid userId)
        {
            var requestStatus = _repository.GetPropertySignRequestStatusForIdAndUser(propertyId, userId);

            return requestStatus;
        }

        public bool PropertySignRequestExists(Guid propertyId, Guid userId)
        {
            bool exists = _repository.PropertySignRequestExists(propertyId, userId);

            return exists;
        }

        public List<SignRequestDetailsDto> GetPropertySignRequestsForPropertyId(Guid propertyId)
        {
            var dtos = _repository.GetPropertySignRequestsForPropertyId(propertyId);

            return dtos;
        }

        public bool SetPropertySignRequest(Guid propertySignRequestId, Guid propertyId, bool accepted)
        {
            var result = false;
            if (accepted)
            {
                result = _repository.SetPropertySignRequestAsAccepted(propertySignRequestId, propertyId);
            }
            else
            {
                result = _repository.SetPropertySignRequestAsDeclined(propertySignRequestId);
            }

            return result;
        }
    }
}
