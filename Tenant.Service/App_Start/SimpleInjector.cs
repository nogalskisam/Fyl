using Fyl.DataLayer.Repositories;
using Fyl.Entities;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tenant.Service.App_Start.SimpleInjector), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tenant.Service.App_Start.SimpleInjector), "Stop")]

namespace Tenant.Service.App_Start
{
    public static class SimpleInjector
    {
        public static void Start()
        {
            var container = new Container();

            container.Register<IAddressRepository, AddressRepository>(Lifestyle.Transient);
            container.Register<IFylEntities>(() => new FylEntities());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        public static void Stop()
        {
        }
    }
}