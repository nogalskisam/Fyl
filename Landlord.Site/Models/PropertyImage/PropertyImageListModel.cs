using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyImageListModel
    {
        public Guid PropertyImageId { get; set; }

        public Guid PropertyId { get; set; }
    }
}