using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class LandlordPropertyListItemDto
    {
        public Guid PropertyId { get; set; }

        public AddressDto Address { get; set; }

        public int Beds { get; set; }

        public string Postcode { get; set; }

        public int SignRequestCount { get; set; }
    }
}
