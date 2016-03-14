using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.Dto
{
    public class PropertyImageDto
    {
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Path { get; set; }
    }
}
