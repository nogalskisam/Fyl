using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyAddBasicDto
    {
        public Guid? PropertyId { get; set; }

        public int Beds { get; set; }

        public decimal Rent { get; set; }

        public decimal Deposit { get; set; }

        public DateTime StartTime { get; set; }

        public Guid? AddressId { get; set; }
    }
}
