using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenant.Service;
using Tenant.Site.Models;

namespace Tenant.Site.Controllers
{
    public class HomeController : Controller
    {
        private ITenantService _tenantService;

        public HomeController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        public ActionResult Index()
        {
            var dto = _tenantService.GetAllAddresses().FirstOrDefault();

            var model = new HomeModel()
            {
                AddressId = dto.AddressId,
                HouseName = dto.HouseName,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Area = dto.Area,
                City = dto.City,
                County = dto.County,
                Country = dto.Country,
                Postcode = dto.Postcode
            };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}