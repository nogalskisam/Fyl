using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Session;
using Fyl.Utilities;
using Landlord.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Landlord.Site.Controllers
{
    public class UserController : Controller
    {
        private readonly ISessionDetails _session;
        private readonly ISessionHelper _sessionHelper;
        private readonly IHttpContextHelper _httpContextHelper;
        private ILandlordService _landlordService;

        public UserController(ILandlordService landlordService, ISessionDetails session, ISessionHelper sessionHelper, IHttpContextHelper httpContextHelper)
        {
            _session = session;
            _sessionHelper = sessionHelper;
            _httpContextHelper = httpContextHelper;
            _landlordService = landlordService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginRequest = new LoginRequestDto()
                    {
                        EmailAddress = model.EmailAddress,
                        Password = model.Password,
                        IpAddress = _httpContextHelper.GetVisitorIpAddress(),
                        IsLandlord = true
                    };

                    var response = await _landlordService.LoginUser(loginRequest);

                    if (response.IsSuccess)
                    {
                        _sessionHelper.SetSessionTicketCookie(response.Session.SessionId);
                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Invalid Credentials");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }

            return View(model);
        }
    }
}