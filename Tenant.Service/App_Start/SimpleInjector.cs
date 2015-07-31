using Fyl.DataLayer.Repositories;
using Fyl.Entities;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tenant.Service.App_Start.SimpleInjector), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tenant.Service.App_Start.SimpleInjector), "Stop")]

namespace Tenant.Service.App_Start
{
    public static class SimpleInjector
    {
        public static void Start()
        {
            CreateKernel();
        }

        private static void CreateKernel()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance:
            RegisterServices(container);

            // Register the container to the SimpleInjectorServiceHostFactory.
            SimpleInjectorServiceHostFactory.SetContainer(container);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IFylEntities>(() => new FylEntities());

            container.RegisterPerWcfOperation<IAddressRepository, AddressRepository>();
        }

        public static void Stop()
        {
        }
    }
}