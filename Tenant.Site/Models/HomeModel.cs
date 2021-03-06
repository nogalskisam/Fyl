﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class HomeModel
    {
        public Guid AddressId { get; set; }

        public string HouseName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string Postcode { get; set; }
    }
}