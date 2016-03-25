using Fyl.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class PropertyModel
    {
        public Guid PropertyId { get; set; }

        [Display(Name = "Beds", ResourceType = typeof(Strings))]
        public int Beds { get; set; }

        public decimal Rent { get; set; }

        [Display(Name = "Rent", ResourceType = typeof(Strings))]
        public string RentDisplay
        {
            get
            {
                return string.Format("£{0}", Rent);
            }
        }

        public decimal Deposit { get; set; }

        [Display(Name = "Deposit", ResourceType = typeof(Strings))]
        public string DepositDisplay
        {
            get
            {
                return string.Format("£{0}", Deposit);
            }
        }

        [Display(Name = "StartDate", ResourceType = typeof(Strings))]
        public DateTime StartDate { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(Strings))]
        public string StartDateDisplay
        {
            get
            {
                return StartDate.ToShortDateString();
            }
        }
        
        public List<Guid> PropertyImageIds { get; set; }

        // Address
        [Display(Name = "Address1", ResourceType = typeof(Strings))]
        public string Address1 { get; set; }

        [Display(Name = "Area", ResourceType = typeof(Strings))]
        public string Area { get; set; }

        [Display(Name = "City", ResourceType = typeof(Strings))]
        public string City { get; set; }

        [Display(Name = "PostCode", ResourceType = typeof(Strings))]
        public string PostCode { get; set; }

        public int RatingAverage { get; set; }
    }
}