using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IAddressRepository
    {
        List<AddressDto> GetAllAddresses();

        Guid AddAddress(AddressAddDto dto);
    }
}
