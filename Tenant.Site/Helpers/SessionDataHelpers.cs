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
        public static object GetSessionData(this HtmlHelper html, string key)
        {
            if (!html.ViewContext.ViewData.ContainsKey(key))
            {
                throw new ArgumentException(string.Format("Cannot retrieve value {0} from session/viewdata as no item exists with this key", key));
            }

            return html.ViewContext.ViewData[key];
        }

        public static UserDto GetSessionUser(this HtmlHelper html)
        {
            return (UserDto)GetSessionData(html, SessionDataKeys.USER);
        }

        public static bool UserIsLoggedIn(this HtmlHelper html)
        {
            return html.ViewContext.ViewData.ContainsKey(SessionDataKeys.USER);
        }
    }
}