using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landlord.Site.Filters
{
    public class LoginFilter : IAuthorizationFilter
    {
        internal readonly ISessionDetails _session;

        public LoginFilter(ISessionDetails sessionFactory)
        {
            _session = sessionFactory;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (_session.IsValid)
            {
                // Redirect
                //filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary
                //    {
                //        { "controller", "User" },
                //        { "action", "Login" }
                //    });

                // Set ViewData values
                filterContext.Controller.ViewData.Add(SessionDataKeys.USER_DISPLAY_NAME, string.Format("{0} {1}", _session.User.FirstName, _session.User.LastName));
                filterContext.Controller.ViewData.Add(SessionDataKeys.USER, _session.User);
            }
        }
    }
}