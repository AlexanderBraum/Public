# DiContainerBuilder
DiContainerBuilder is a simple .NET library that allows you to automatically register classes and their interfaces in the dependency injection container.

This project is inspired by [NetCore.AutoRegisterDi](https://github.com/JonPSmith/NetCore.AutoRegisterDi). I've added a feature to register concrete classes.

## Features

- Automatically scan assemblies for classes
- Flexible filtering of types to register
- Register via interface or concrete class
- Support for different lifetimes (Transient, Scoped, Singleton)

## Installation

Add the project to your solution and reference it from your application.

## Usage

Below is an example of how to use DiContainerBuilder in an ASP.NET Core project:

```csharp
using DiContainerBuilder;
using Microsoft.Extensions.DependencyInjection;

public void ConfigureServices(IServiceCollection services)
{
    // Scan the current assembly for classes
    services
        .ScanAssemblyForTypes()
        // Optional: filter types, for example only types ending with "Service"
        .Where(type => type.Name.EndsWith("Service"))
        // Register all found types via their interfaces as Transient
        .RegisterTypesViaInterface(ServiceLifetime.Transient);
}
```

### Registering via concrete class

If you want to register types as concrete classes:

```csharp
services
    .ScanAssemblyForTypes()
    .RegisterTypesViaClass(ServiceLifetime.Transient);
```

## Notes

This is an example project meant for learning purposes; use in production at your own risk.
