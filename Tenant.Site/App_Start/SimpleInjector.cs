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

namespace Tenant.Site.App_Start
{
    public class SimpleInjector
    {
        public static void Start()
        {
            var container = CreateKernel();
        }

        public static void Stop()
        {
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static Container CreateKernel()
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
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, new Assembly[] { typeof(SimpleInjector).Assembly });
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            // Register filters.
            RegisterGlobalFilters(GlobalFilters.Filters, container);
            RegisterWebApiFilters(GlobalConfiguration.Configuration.Filters, container);

            return container;
        }

        private static void RegisterServices(Container container)
        {
            container.RegisterSingle<ILog>(() => LogManager.GetLogger(typeof(SimpleInjector)));
            //container.RegisterPerWebRequest<ISessionDetails>(() => SessionFactory.Create());

            // Configure WCF services.
            // It's essential to bind the ProxyGenerator to a singleton, or no caching of the Castle WCF proxies will occur.
            //container.RegisterSingle<ProxyGenerator>(() => new ProxyGenerator());

            //ChannelFactoryCache.Add<IProjectService>(ProjectServiceChannelHelper.GetUri(), ProjectServiceChannelHelper.GetBinding(ProjectServiceChannelHelper.GetUri()), new List<IEndpointBehavior> { new WcfMiniProfilerBehavior() });
            //container.RegisterSingle<IProjectService>(() => CreateWcfClient<IProjectService>(container));

            // OK, onto other things!
            //container.RegisterPerWebRequest<ICacheHelper, CacheHelper>();
            //container.RegisterPerWebRequest<IOrganisationPermissionResolver, OrganisationPermissionResolver>();
            //container.RegisterPerWebRequest<IUserPermissionResolver, UserPermissionResolver>();

            //container.Register<ExceptionLoggingFilter>();
            //container.Register<SetSessionDetailsViewDataFilter>();

            // Filters.
            //container.Register<UserFeaturesActionFilter>(() => new UserFeaturesActionFilter(UserGroupMode.TmsFeatureGroups, () =>
            //    AdministrationUserHelper.GetUserFeatures(container.GetInstance<Administration.Library.ServiceInterface.Async.IAdministrationService>(), container.GetInstance<ISessionDetails>().User.UserId)));

            // Register MVC generic filters.
            //container.RegisterManyForOpenGeneric(
            //    typeof(IMvcActionFilter<>), container.RegisterAll,
            //    typeof(IMvcActionFilter<>).Assembly);

            //GlobalFilters.Filters.Add(new MvcActionFilterDispatcher(container.GetAllInstances));

            // Register Web API filters.
            //GlobalConfiguration.Configuration.Filters.Add(
            //    new ActionFilterDispatcher(container.GetAllInstances));

            //container.RegisterManyForOpenGeneric(
            //    typeof(IWebApiActionFilter<>), container.RegisterAll,
            //    typeof(IWebApiActionFilter<>).Assembly);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters, Container container)
        {
            //Add simple injector resolved types.
            //filters.Add(container.GetInstance<ExceptionLoggingFilter>());
            //filters.Add(container.GetInstance<SetSessionDetailsViewDataFilter>());
            //filters.Add(container.GetInstance<UserFeaturesActionFilter>());
        }

        private static void RegisterWebApiFilters(System.Web.Http.Filters.HttpFilterCollection httpFilterCollection, Container container)
        {

        }

        //private static T CreateWcfClient<T>(Container container) where T : class
        //{
                //return container
                //    .GetInstance<ProxyGenerator>()
                //    .CreateIn;
                //.CreateInterfaceProxyWithoutTarget<T>(new WcfProxyWithDisposalInterceptor<T>());
        //}
    }
}