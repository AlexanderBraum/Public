using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DiContainerBuilder
{

    public static class DiContainerBuilderExtensions
    {
        public static DiContainerBuilderContainer ScanAssemblyForTypes(
           this IServiceCollection services)
        {
            var assemblies = new[] { Assembly.GetCallingAssembly() };
            var result = services.ScanAssembliesForTypes(assemblies);
            return result;
        }

        public static DiContainerBuilderContainer ScanAssembliesForTypes(
            this IServiceCollection services,
            Assembly[] assemblies)
        {
            var result = assemblies
                .SelectMany(x => x.GetExportedTypes())
                .Where(x => x.IsClass)
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericType)
                .Where(x => !x.IsNested);
            return new DiContainerBuilderContainer(services, result);
        }

        public static DiContainerBuilderContainer Where(
            this DiContainerBuilderContainer container,
            Func<Type, bool> predicate)
        {
            var TypesToRegister = container.TypesToRegister.Where(predicate);
            var result = new DiContainerBuilderContainer(container.Services, TypesToRegister);
            return result;
        }

        public static IEnumerable<(Type interfaceType, Type type)> RegisterTypesViaInterface(
            this DiContainerBuilderContainer container,
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
        this DiContainerBuilderContainer container,
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
