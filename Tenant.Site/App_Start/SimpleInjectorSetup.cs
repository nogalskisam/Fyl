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
using System.ServiceModel;
using Fyl.Library;
using Fyl.Utilities;
using Fyl.Session;
using Tenant.Site.Filters;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tenant.Site.App_Start.SimpleInjectorSetup), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tenant.Site.App_Start.SimpleInjectorSetup), "Stop")]

namespace Tenant.Site.App_Start
{
    public class SimpleInjectorSetup
    {
        public static void Start()
        {
            var container = SetupContainer();
        }

        public static void Stop()
        {
        }

        private static Container SetupContainer()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            RegisterServices(container);

            // Setup MVC.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            // Setup WebApi.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // Register filters.
            RegisterGlobalFilters(GlobalFilters.Filters, container);
            RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters, container);

            container.Verify();

            return container;
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            //filters.Add(container.GetInstance<LoginFilter>());
        }

        private static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection httpFilterCollection, Container container)
        {

        }

        private static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<ISessionDetails, SessionDetails>();
            container.RegisterPerWebRequest<ISessionHelper, SessionHelper>();
            container.RegisterPerWebRequest<ISessionFactory, TenantSessionFactory>();
            container.RegisterPerWebRequest<IHttpContextHelper, HttpContextHelper>();
            container.RegisterPerWebRequest<IEncryptionHelper, EncryptionHelper>();
            container.Register<HttpContextBase>(() =>
                new HttpContextWrapper(HttpContext.Current),
                Lifestyle.Singleton);

            // WCF
            container.RegisterSingleton<ITenantService>(() => new ChannelFactory<ITenantService>("*").CreateChannel());

        }
    }
}