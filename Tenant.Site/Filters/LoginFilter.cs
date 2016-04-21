using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tenant.Site.Filters
{
    public class LoginFilter : IAuthorizationFilter
    {
        internal readonly ISessionDetails _session;

        public LoginFilter(ISessionDetails session)
        {
            _session = session;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (!_session.IsAuthenticated)
                {
                    // Redirect
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            { "controller", "User" },
                            { "action", "Login" }
                        });

                }
            }
            catch (Exception)
            {
                // user might not be logged in
                throw;
            }
        }
    }
}