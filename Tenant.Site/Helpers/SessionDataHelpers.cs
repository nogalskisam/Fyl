using Fyl.Library.Dto;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tenant.Site.Helpers
{
    public static class SessionDataHelpers
    {
        public static object GetSessionData(this HtmlHelper html)
        {
            if (html.ViewBag.SessionDetails == null)
            {
                throw new ArgumentException("Cannot retrieve session/viewdata as no item exists with this key");
            }

            return html.ViewBag.SessionDetails;
        }

        public static UserDto GetSessionUser(this HtmlHelper html)
        {
            return ((ISessionDetails)GetSessionData(html)).User;
        }

        public static bool UserIsLoggedIn(this HtmlHelper html)
        {
            return ((ISessionDetails)GetSessionData(html)).IsAuthenticated;
        }
    }
}