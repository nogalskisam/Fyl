using Fyl.Library.Dto;
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
        PropertyDetailsDto GetPropertyDetails(Guid propertyId);
    }
}
