using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyListResponseDto
    {
        public List<PropertyListItemDto> Items { get; set; }

        public int Count { get; set; }
    }
}
