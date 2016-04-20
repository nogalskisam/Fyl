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
        internal readonly ISessionFactory _session;

        public LoginFilter(ISessionFactory sessionFactory)
        {
            _session = sessionFactory;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                var session = _session.GetSession();
                if (_session.GetSession().IsValid)
                {
                    // Redirect
                    //filterContext.Result = new RedirectToRouteResult(
                    //    new RouteValueDictionary
                    //    {
                    //        { "controller", "User" },
                    //        { "action", "Login" }
                    //    });

                    // Set ViewData values
                    filterContext.Controller.ViewData.Add(SessionDataKeys.USER_DISPLAY_NAME, string.Format("{0} {1}", session.User.FirstName, session.User.LastName));
                    filterContext.Controller.ViewData.Add(SessionDataKeys.USER, session.User);
                }
            }
            catch (Exception)
            {
                // user might not be logged in
            }
        }
    }
}