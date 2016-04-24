using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
        }

        public AddressModel(PropertyBasicDetailsDto dto)
        {
            Address1 = dto.Address1;
            Area = dto.Area;
            City = dto.City;
            PostCode = dto.PostCode;
        }

        public AddressModel(PropertyDetailedDto dto)
        {
            AddressId = dto.AddressId;
            HouseName = dto.HouseName;
            Address1 = dto.Address1;
            Address2 = dto.Address2;
            Area = dto.Area;
            City = dto.City;
            County = dto.County;
            Country = dto.Country;
            PostCode = dto.PostCode;
        }

        public Guid? AddressId { get; set; }

        public string HouseName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Area { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}