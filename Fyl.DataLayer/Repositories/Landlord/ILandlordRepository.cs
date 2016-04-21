using Fyl.Library.Dto;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface ILandlordRepository
    {
        UserDto Register(RegistrationRequestDto dto, SaltedHashResult auth);
    }
}
