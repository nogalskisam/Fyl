using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class ImageUploadModel
    {
        public Guid PropertyId { get; set; }

        [Required]
        [Display(Name = "Image")]
        public List<HttpPostedFileBase> Images { get; set; }
    }
}