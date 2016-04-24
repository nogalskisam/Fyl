using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library
{
    [ServiceContract]
    public interface ILandlordService
    {
        [OperationContract]
        Task<LoginResponseDto> LoginUser(LoginRequestDto dto);

        [OperationContract]
        SessionDetailDto GetValidSession(Guid sessionId);

        [OperationContract]
        Guid AddProperty(Guid userId, PropertyAddEditDto dto);

        [OperationContract]
        Task<RegistrationResponseDto> RegisterUser(RegistrationRequestDto dto);

        [OperationContract]
        LandlordPropertyListResponseDto GetPropertiesForLandlordList(Guid userId);

        [OperationContract]
        PropertyBasicDetailsDto GetPropertyBasicDetails(Guid propertyId);

        [OperationContract]
        List<PropertyImageDto> GetPropertyImagesForProperty(Guid propertyId);

        [OperationContract]
        Guid AddPropertyImage(Guid propertyId);

        [OperationContract]
        PropertyImageDetailDto GetPropertyImage(Guid propertyImageId);

        [OperationContract]
        bool UpdatePropertyImage(PropertyImageDetailDto dto);

        [OperationContract]
        List<SignRequestDetailsDto> GetPropertySignRequestsForPropertyId(Guid propertyId);

        [OperationContract]
        bool SetPropertySignRequest(Guid propertySignRequestId, Guid propertyId, bool accepted);

        [OperationContract]
        PropertyDetailedDto GetPropertyDetails(Guid propertyId);

        [OperationContract]
        Guid EditProperty(Guid userId, PropertyAddEditDto dto);
    }
}
