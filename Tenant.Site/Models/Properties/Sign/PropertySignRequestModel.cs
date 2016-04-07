using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class PropertySignRequestModel
    {
        public Guid PropertyId { get; set; }

        public int Beds { get; set; }

        public decimal Rent { get; set; }

        public decimal Deposit { get; set; }

        public DateTime StartDate { get; set; }

        public string Address1 { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        [Required]
        public bool AcceptTermsAndConditions { get; set; }
    }
}