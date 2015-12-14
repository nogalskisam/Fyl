using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tenant.Site.Models
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }

        public RegisterDto ToDto()
        {
            return new RegisterDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                ContactNumber = ContactNumber,
                EmailAddress = EmailAddress,
                DateOfBirth = DateTime.UtcNow
            };
        }
    }
}