using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class PropertyDetailedModel
    {
        public PropertyDetailedModel()
        {
        }

        public PropertyDetailedModel(PropertyBasicDetailsDto dto)
        {
            Property = new PropertyModel(dto);
            Address = new AddressModel(dto);
        }

        public PropertyDetailedModel(PropertyDetailedDto dto)
        {
            Property = new PropertyModel(dto);
            Address = new AddressModel(dto);
            Tenants = dto.Tenants;
        }

        public PropertyModel Property { get; set; }

        public AddressModel Address { get; set; }

        public List<UserDto> Tenants { get; set; }
    }
}