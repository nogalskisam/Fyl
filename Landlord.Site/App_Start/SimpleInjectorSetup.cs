using Fyl.Library;
using Fyl.Session;
using Fyl.Utilities;
using Landlord.Service;
using Landlord.Site.Filters;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

//[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Landlord.Site.App_Start.SimpleInjectorSetup), "Start")]
//[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Landlord.Site.App_Start.SimpleInjectorSetup), "Stop")]

namespace Landlord.Site.App_Start
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
            filters.Add(container.GetInstance<LoginFilter>());
        }

        private static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection httpFilterCollection, Container container)
        {

        }

        private static void RegisterServices(Container container)
        {
            container.RegisterPerWebRequest<ISessionDetails, SessionDetails>();
            container.RegisterPerWebRequest<ISessionHelper, SessionHelper>();
            container.RegisterPerWebRequest<ISessionFactory, LandlordSessionFactory>();
            container.RegisterPerWebRequest<IHttpContextHelper, HttpContextHelper>();
            container.RegisterPerWebRequest<IEncryptionHelper, EncryptionHelper>();
            container.Register<HttpContextBase>(() =>
                new HttpContextWrapper(HttpContext.Current),
                Lifestyle.Singleton);

            // WCF
            container.Register<ILandlordService>(() => new ChannelFactory<ILandlordService>("*").CreateChannel());

            //container.RegisterSingleton(() => ILandlordService_Channel.Create());
            //container.Register<ILandlordService, LandlordService>(Lifestyle.Singleton);
        }
    }
}