using System.Web;
using System.Web.Mvc;
using Tenant.Site.Attributes;

namespace Tenant.Site
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UnsecuredAttribute());
        }
    }
}
