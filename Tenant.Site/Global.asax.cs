using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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
            MapperConfig.RegisterMaps();
            SimpleInjectorSetup.Start();
        }
    }
}
