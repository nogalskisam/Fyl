using Ninject.Syntax;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Landlord.Service.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Landlord.Service.App_Start.NinjectWebCommon), "Stop")]

namespace Landlord.Service.App_Start
{
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.ServiceModel.Description;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using System.Diagnostics;
    using Fyl.Library;
    using Fyl.Entities;
    using Fyl.Managers;
    using Fyl.DataLayer;
    using Fyl.DataLayer.Repositories;
    using Fyl.Session;

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

            // Set up object mappings for mappings defined in "Automation" assemblies
            //ObjectMapper.InitialiseMappings("Automation");
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILandlordService>().To<LandlordService>();
            kernel.Bind<IFylEntities>().To<FylEntities>();

            kernel.Bind<IPropertyManager>().To<PropertyManager>();
            kernel.Bind<IPropertySignRequestManager>().To<PropertySignRequestManager>();
            kernel.Bind<IUserManager>().To<UserManager>();

            kernel.Bind<IAddressRepository>().To<AddressRepository>();
            kernel.Bind<IPropertyRepository>().To<PropertyRepository>();
            kernel.Bind<IPropertySignRequestRepository>().To<PropertySignRequestRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();

            kernel.Bind<IPasswordHasher>().To<PasswordHasher>();
        }
    }
}