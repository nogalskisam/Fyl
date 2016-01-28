using Fyl.Library.Dto;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tenant.Service;
using Tenant.Site.Models;

namespace Tenant.Site.Controllers
{
    public class AccountController : Controller
    {
        private ITenantService _tenantService;

        public AccountController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong! Please try again later");

                return View(model);
            }
            else
            {
                var dto = model.ToTenantDto();

                try
                {
                    await _tenantService.RegisterUser(dto);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex);

                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong! Please try again later");

                return View(model);
            }
            else
            {
                UserProfileSessionData profileData = new UserProfileSessionData();
                var dto = model.ToLoginDto();

                profileData = await _tenantService.LoginUser(dto);

                if (true)
                {
                    profileData = new UserProfileSessionData()
                    {
                        UserId = Guid.NewGuid(),
                        FirstName = "Samuel",
                        LastName = "Nogalski",
                        EmailAddress = "test@test.co.uk",
                        Role = RoleEnum.Tenant
                    };

                    this.Session["Profile"] = profileData;
                }

                return RedirectToAction("Index", "Home");
            }
        }
    }
}