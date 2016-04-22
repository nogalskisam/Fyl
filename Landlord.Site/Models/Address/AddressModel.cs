using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class AddressModel
    {
        public Guid? AddressId { get; set; }

        [Required]
        public string HouseName { get; set; }

        [Required]
        public string Address1 { get; set; }

        [Required]
        public string Address2 { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string City { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}