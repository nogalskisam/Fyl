using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class PropertyImage
    {
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public bool Primary { get; set; }

        public bool Inactive { get; set; }
    }
}
