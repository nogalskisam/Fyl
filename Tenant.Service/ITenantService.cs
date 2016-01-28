using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Tenant.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITenantService
    {
        // TODO: Add your service operations here
        [OperationContract]
        List<AddressDto> GetAllAddresses();

        [OperationContract]
        Task RegisterUser(RegistrationRequestDto dto);

        [OperationContract]
        Task<UserProfileSessionData> LoginUser(LoginDto dto);
    }
}
