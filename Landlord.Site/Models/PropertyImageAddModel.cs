using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyImageAddModel
    {
        public Guid PropertyId { get; set; }

        public HttpPostedFileBase PrimaryImage { get; set; }

        public List<HttpPostedFileBase> RegularImages { get; set; }
    }
}