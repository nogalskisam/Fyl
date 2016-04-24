using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyAddEditDto
    {
        public virtual PropertyAddBasicDto Property { get; set; }

        public virtual AddressAddDto Address { get; set; }
    }
}
