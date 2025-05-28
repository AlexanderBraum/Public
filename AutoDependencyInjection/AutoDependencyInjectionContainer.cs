using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AutoDependencyInjection
{

    public class AutoDependencyInjectionContainer
    {
        public IEnumerable<Type> TypesToRegister { get; set; }
        public IServiceCollection Services { get; set; }

        public AutoDependencyInjectionContainer(IServiceCollection services, IEnumerable<Type> typesToRegister)
        {
            Services = services;
            TypesToRegister = typesToRegister;
        }
    }
}
