using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Fyl.Library
{
    [ServiceContract]
    public interface ITenantService
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<AddressDto> GetAllAddresses();

        [OperationContract]
        Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto);

        [OperationContract]
        Task<LoginResponseDto> LoginUser(LoginRequestDto dto);

        [OperationContract]
        SessionDetailDto GetValidSession(Guid sessionId);

        [OperationContract]
        PropertyListResponseDto GetAvailablePropertiesForList(PropertyListRequestDto request);

        [OperationContract]
        PropertyBasicDetailsDto GetPropertyDetails(Guid propertyId);

        [OperationContract]
        void AddNewPropertySignRequest(Guid propertyId, Guid userId);

        [OperationContract]
        PropertyRequestStatusEnum GetPropertySignRequestForIdAndUser(Guid propertyId, Guid userId);

        [OperationContract]
        bool PropertySignRequestExists(Guid propertyId, Guid userId);

        [OperationContract]
        PropertyDetailedDto GetPropertyForTenantUser(Guid userId);
    }
}
