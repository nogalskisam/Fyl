using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using SimpleInjector.Integration.WebApi;
using log4net;
using Castle.DynamicProxy;
using System.Web.Http;
using Tenant.Service;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tenant.Site.App_Start.SimpleInjectorSetup), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tenant.Site.App_Start.SimpleInjectorSetup), "Stop")]

namespace Tenant.Site.App_Start
{
    public class SimpleInjectorSetup
    {
        public static void Start()
        {
            var container = new Container();

            container.Register<ITenantService, TenantService>(Lifestyle.Transient);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void Stop()
        {
        }
    }
}