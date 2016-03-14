using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fyl.Library.Dto
{
    public class PropertyImageAddDto
    {
        public Guid PropertyId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public bool Primary { get; set; }
    }
}
