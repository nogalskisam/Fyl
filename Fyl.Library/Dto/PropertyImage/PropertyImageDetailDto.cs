using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyImageDetailDto
    {
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }

        public bool Primary { get; set; }

        public bool Inactive { get; set; }
    }
}
