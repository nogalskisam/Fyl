using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Mapping
{
    public static class ObjectMapper
    {
        public static TDest Map<TDest>(object source)
        {
            return Mapper.Map<TDest>(source);
        }

        public static void InitialiseMappings(string assemblyNameFilter)
        {
            foreach (var assembly in GetAllAssemblies(assemblyNameFilter))
            {
                foreach (Type implementingType in assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IObjectMapping))))
                {
                    IObjectMapping instance = Activator.CreateInstance(implementingType) as IObjectMapping;
                    instance.CreateMaps();
                }
            }
        }

        public static void AssertConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

        private static IEnumerable<Assembly> GetAllAssemblies(string assemblyNameFilter = null)
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().AsEnumerable();
            if (!string.IsNullOrEmpty(assemblyNameFilter))
            {
                allAssemblies = allAssemblies.Where(t => t.FullName.StartsWith(assemblyNameFilter));
            }
            return allAssemblies;
        }
    }
}
