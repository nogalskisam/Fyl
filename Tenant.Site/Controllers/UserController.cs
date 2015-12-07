using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenant.Service;

namespace Tenant.Site.Controllers
{
    public class UserController : Controller
    {
        private ITenantService _tenantService;

        public UserController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }


    }
}