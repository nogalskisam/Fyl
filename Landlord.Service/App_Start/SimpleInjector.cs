using Fyl.DataLayer.Repositories;
using Fyl.Entities;
using Fyl.Managers;
using Fyl.Session;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Landlord.Service.App_Start.SimpleInjector), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Landlord.Service.App_Start.SimpleInjector), "Stop")]

namespace Landlord.Service.App_Start
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
            container.RegisterPerWcfOperation<IUserRepository, UserRepository>();
            container.RegisterPerWcfOperation<IUserManager, UserManager>();
            container.RegisterPerWcfOperation<IPropertyRepository, PropertyRepository>();
            container.RegisterPerWcfOperation<IPropertyManager, PropertyManager>();

            container.RegisterPerWcfOperation<IPasswordHasher, PasswordHasher>();
            //container.RegisterPerWcfOperation<IHasher, Hasher>();
        }

        public static void Stop()
        {
        }
    }
}