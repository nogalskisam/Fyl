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
        internal readonly ISessionFactory _sessionFactory;

        public LoginFilter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var session = _sessionFactory.GetSession();
            if (_sessionFactory.GetSession().IsValid)
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
    }
}