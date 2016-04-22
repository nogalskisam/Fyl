using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyModel
    {
        [Required]
        public int Beds { get; set; }

        [Required]
        public decimal Rent { get; set; }

        [Required]
        public decimal Deposit { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}