using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyModel
    {
        public PropertyModel()
        {
        }

        public PropertyModel(PropertyBasicDetailsDto dto)
        {
            Beds = dto.Beds;
            Rent = dto.Rent;
            Deposit = dto.Deposit;
            StartDate = dto.StartDate;
        }

        public PropertyModel(PropertyDetailedDto dto)
        {
            PropertyId = dto.PropertyId;
            Beds = dto.Beds;
            Rent = dto.Rent;
            Deposit = dto.Deposit;
            StartDate = dto.StartDate;
        }

        public Guid? PropertyId { get; set; }

        [Required]
        public int Beds { get; set; }

        [Required]
        public decimal Rent { get; set; }

        [Required]
        public decimal Deposit { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        //public List<PropertyFeatureEnum> Features { get; set; }
    }
}