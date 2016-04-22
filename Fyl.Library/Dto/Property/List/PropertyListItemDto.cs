using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyListItemDto
    {
        // Property
        public Guid PropertyId { get; set; }

        public Guid? PropertyImageId { get; set; }

        public int Beds { get; set; }

        public string Postcode { get; set; }

        public string ImagePath { get; set; }
    }
}
