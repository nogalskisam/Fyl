using Fyl.Library.Dto;
using Fyl.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class PropertyImageDetailModel
    {
        public PropertyImageDetailModel()
        {
        }

        public PropertyImageDetailModel(PropertyImageDetailDto dto)
        {
            PropertyImageId = dto.PropertyImageId;
            PropertyId = dto.PropertyId;
            Primary = dto.Primary;
            Inactive = dto.Inactive;
        }

        [Required]
        public Guid PropertyImageId { get; set; }

        [Required]
        public Guid PropertyId { get; set; }

        [Required]
        public bool Primary { get; set; }

        [Required]
        [Display(Name = "Delete", ResourceType = typeof(Strings))]
        public bool Inactive { get; set; }

        public PropertyImageDetailDto ToDto()
        {
            return new PropertyImageDetailDto()
            {
                PropertyImageId = PropertyImageId,
                PropertyId = PropertyId,
                Primary = Primary,
                Inactive = Inactive
            };
        }
    }
}