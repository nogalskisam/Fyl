using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tenant.Service;
using Tenant.Site.App_Start;

namespace Tenant.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //SimpleInjectorSetup.Start();

            var container = new Container();

            // 2. Configure the container (register)
            // See below for more configuration examples
            container.RegisterSingle<ITenantService, TenantService>();

            container.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());

            container.RegisterMvcIntegratedFilterProvider();

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
}
