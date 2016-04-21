using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tenant.Site.Filters
{
    public class SetSessionDetailViewDataFilter : IActionFilter
    {
        private ISessionDetails _details;

        public SetSessionDetailViewDataFilter(ISessionDetails details)
        {
            _details = details;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            return;
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.SessionDetails = _details;
        }
    }
}