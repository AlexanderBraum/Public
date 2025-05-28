using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DiContainerBuilder
{

    public class DiContainerBuilderContainer
    {
        public IEnumerable<Type> TypesToRegister { get; set; }
        public IServiceCollection Services { get; set; }

        public DiContainerBuilderContainer(IServiceCollection services, IEnumerable<Type> typesToRegister)
        {
            Services = services;
            TypesToRegister = typesToRegister;
        }
    }
}
