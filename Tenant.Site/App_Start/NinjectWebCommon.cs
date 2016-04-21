[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tenant.Site.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tenant.Site.App_Start.NinjectWebCommon), "Stop")]

namespace Tenant.Site.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Fyl.Library;
    using Filters;
    using Attributes;
    using Fyl.Session;
    using Fyl.Utilities;
    using Fyl.Library.ServiceInterface;
    using Ninject.Web.Mvc.FilterBindingSyntax;
    using System.Web.Mvc;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISessionFactory>().To<TenantSessionFactory>();
            kernel.Bind<ISessionDetails>().ToMethod(c =>
            {
                ISessionDetails sessionDetails = null;
                try
                {
                    var sessionFactory = new TenantSessionFactory();
                    sessionDetails = sessionFactory.GetSession();
                }
                catch (Exception)
                {

                }
                return sessionDetails;
            });
            kernel.Bind<ISessionHelper>().To<SessionHelper>();
            kernel.Bind<IHttpContextHelper>().To<HttpContextHelper>();
            kernel.Bind<IEncryptionHelper>().To<EncryptionHelper>();
            kernel.BindFilter<SetSessionDetailViewDataFilter>(FilterScope.Global, null).When(r => true);

            kernel.Bind<ITenantService>().ToMethod(c => ITenantService_Channel.Create());

            kernel.BindFilter<LoginFilter>(System.Web.Mvc.FilterScope.Action, 0).WhenActionMethodHasNo<UnsecuredAttribute>();
        }        
    }
}
