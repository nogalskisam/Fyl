using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landlord.Site.Models
{
    public class LoginModel
    {
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public LoginRequestDto ToLoginDto()
        {
            return new LoginRequestDto()
            {
                EmailAddress = EmailAddress,
                Password = Password
            };
        }
    }
}