using Fyl.Library.Enum;
using Fyl.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
            try
            {
                if (_session.IsAuthenticated && _session.User.Role != RoleEnum.Landlord)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary
                        {
                            { "controller", "Error" },
                            { "action", "ErrorTenant" }
                        });
                }
                else if (!_session.IsAuthenticated)
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