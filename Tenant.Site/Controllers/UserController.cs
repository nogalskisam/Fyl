﻿using Fyl.Library;
using Fyl.Library.Dto;
using Fyl.Session;
using Fyl.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tenant.Site.Attributes;
using Tenant.Site.Models;

namespace Tenant.Site.Controllers
{
    public class UserController : Controller
    {
        private readonly ISessionDetails _session;
        private readonly ISessionHelper _sessionHelper;
        private readonly IHttpContextHelper _httpContextHelper;
        private ITenantService _tenantService;

        public UserController(ITenantService tenantService, ISessionDetails session, ISessionHelper sessionHelper, IHttpContextHelper httpContextHelper)
        {
            _session = session;
            _sessionHelper = sessionHelper;
            _httpContextHelper = httpContextHelper;
            _tenantService = tenantService;
        }

        [HttpGet]
        [Unsecured]
        public ActionResult Register()
        {
            var model = new RegisterModel();

            return View("Register", model);
        }

        [HttpPost]
        [Unsecured]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (model.Password != model.PasswordConfirm)
            {
                model.Password = null;
                model.PasswordConfirm = null;

                ModelState.AddModelError("", "Passwords do not match!");
            }

            if (ModelState.IsValid)
            {
                RegistrationResponseDto response = await _tenantService.RegisterUser(model.ToTenantDto());

                if (response.Success)
                {
                    return RedirectToAction("Success", "User");
                }

                if (response.EmailExists)
                {
                    ModelState.AddModelError("EmailAddress", "Email address already exists");
                }
            }

            return View(model);
        }

        [Unsecured]
        public ViewResult Success()
        {
            return View("Success");
        }

        [HttpGet]
        [Unsecured]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Unsecured]
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
                        IpAddress = _httpContextHelper.GetVisitorIpAddress()
                    };

                    var response = await _tenantService.LoginUser(loginRequest);

                    if (response.IsSuccess)
                    {
                        _sessionHelper.SetSessionTicketCookie(response.Session.SessionId);
                        return RedirectToAction("List", "Property");
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

        [HttpGet]
        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}