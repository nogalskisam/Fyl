using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class PropertyImageModel
    {
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public string Path { get; set; }
    }
}