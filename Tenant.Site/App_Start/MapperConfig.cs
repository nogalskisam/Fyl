using Fyl.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tenant.Site.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterMaps()
        {
            ObjectMapper.InitialiseMappings("Fyl");
        }
    }
}