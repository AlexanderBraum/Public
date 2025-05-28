using AutoDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoDependencyInjection
{

    public static class AutoDependencyInjectionRegisterExtensions
    {
        public static AutoDependencyInjectionContainer ScanAssemblyForTypes(
           this IServiceCollection services)
        {
            var assemblies = new[] { Assembly.GetCallingAssembly() };
            var result = services.ScanAssembliesForTypes(assemblies);
            return result;
        }

        public static AutoDependencyInjectionContainer ScanAssembliesForTypes(
            this IServiceCollection services,
            Assembly[] assemblies)
        {
            var result = assemblies
                .SelectMany(x => x.GetExportedTypes())
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericType)
                .Where(x => !x.IsNested);
            return new AutoDependencyInjectionContainer(services, result);
        }

        public static AutoDependencyInjectionContainer Where(
            this AutoDependencyInjectionContainer container,
            Func<Type, bool> predicate)
        {
            var TypesToRegister = container.TypesToRegister.Where(predicate);
            var result = new AutoDependencyInjectionContainer(container.Services, TypesToRegister);
            return result;
        }

        public static IEnumerable<(Type interfaceType, Type type)> RegisterTypesViaInterface(
            this AutoDependencyInjectionContainer container,
            ServiceLifetime serviceLifetime)
        {
            var  registredTypes = new List<(Type interfaceType, Type type)>();

            foreach (var type in container.TypesToRegister)
            {
                var interfaces = type.GetInterfaces();
                foreach (var interfaceType in interfaces)
                {
                    container.Services.Add(new ServiceDescriptor(interfaceType, type, serviceLifetime));
                    registredTypes.Add((interfaceType, type));
                }
            }
            return registredTypes;
        }

        public static IEnumerable<Type> RegisterTypesViaClass(
        this AutoDependencyInjectionContainer container,
        ServiceLifetime serviceLifetime)
        {
            var registredTypes = new List<Type>();

            foreach (var type in container.TypesToRegister)
            {
                container.Services.Add(new ServiceDescriptor(type, type, serviceLifetime));
                registredTypes.Add(type);
            }
            return registredTypes;
        }
    }
}
