using Fyl.Library.Dto;
using Fyl.Library.Enum;
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

        [Required]
        public string Password { get; set; }

        [Required]
        public string PasswordConfirm { get; set; }

        public DateTime DateOfBirth { get; set; }

        public RegisterDto ToDto()
        {
            return new RegisterDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                PasswordConfirm = PasswordConfirm,
                ContactNumber = ContactNumber,
                EmailAddress = EmailAddress,
                DateOfBirth = DateTime.UtcNow
            };
        }

        public RegisterDto ToTenantDto()
        {
            return new RegisterDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                PasswordConfirm = PasswordConfirm,
                ContactNumber = ContactNumber,
                EmailAddress = EmailAddress,
                DateOfBirth = DateTime.UtcNow,
                DateRegistered = DateTime.UtcNow,
                Role = RoleEnum.Tenant
            };
        }
    }
}