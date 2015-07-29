using Fyl.Entities;
using Fyl.Library.Dto;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        //private ILog _logger;
        private IFylEntities _entities;

        public AddressRepository(/*ILog logger,*/ IFylEntities entities)
        {
            /*_logger = logger;*/
            _entities = entities;
        }

        public List<AddressDto> GetAllAddresses()
        {
            var entities = _entities.Addresses.ToList();

            var dtos = entities.Select(s => new AddressDto()
            {
                AddressId = s.AddressId,
                HouseName = s.HouseName,
                Address1 = s.Address1,
                Address2 = s.Address2,
                Area = s.Area,
                City = s.City,
                County = s.County,
                Country = s.Country,
                Postcode = s.Postcode
            }).ToList();

            return dtos;
        }
    }
}
