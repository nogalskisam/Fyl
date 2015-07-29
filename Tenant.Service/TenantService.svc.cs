using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Tenant.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TenantService : ITenantService
    {
        //private ILog _logger;
        private IAddressRepository _addressRepository;

        public TenantService(/*ILog logger,*/ IAddressRepository addressRepository)
        {
            //_logger = logger;
            _addressRepository = addressRepository;
        }

        public List<AddressDto> GetAllAddresses()
        {
            var dtos = _addressRepository.GetAllAddresses();

            return dtos;
        }
    }
}
