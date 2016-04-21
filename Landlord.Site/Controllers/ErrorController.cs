using Landlord.Site.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landlord.Site.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {
        }

        [Unsecured]
        public ActionResult Error()
        {
            object model = "An error was found";

            return View("Error", model);
        }

        [Unsecured]
        public ActionResult ErrorTenant()
        {
            object model = "You tried to access the Landlord site when you are a Tenant.";

            return View("Error", model);
        }
    }
}