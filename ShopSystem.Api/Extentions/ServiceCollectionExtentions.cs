using ShopSystem.Domain.Interfaces;
using ShopSystem.Domain.Models;
using ShopSystem.infrastructure.Repositories;
using ShopSystem.Services;
using System.Reflection;

namespace ShopSystem.Api.Extentions;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddGenericRepositories(this IServiceCollection services)
    {
        Assembly entityAssembly = typeof(Product).Assembly;

        Type repositoryInterface = typeof(IRepository<,>);
        Type repositoryImplementation = typeof(Repository<,>);

        var entityTypes = entityAssembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseEntity<>)));

        foreach (var entityType in entityTypes)
        {
            Type entityInterface = entityType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseEntity<>));

            Type TId = entityInterface.GetGenericArguments()[0];

            Type concreteInterface = repositoryInterface.MakeGenericType(entityType, TId);
            Type concreteImplementation = repositoryImplementation.MakeGenericType(entityType, TId);

            services.AddScoped(concreteInterface, concreteImplementation);
        }

        return services;
    }

    public static IServiceCollection AddAutoServices(this IServiceCollection services)
    {
        Assembly servicesAssembly = typeof(IAutoServiceRegister).Assembly;

        var concreteServiceTypes = servicesAssembly.GetTypes()
            .Where(t => t.IsClass
                     && !t.IsAbstract
                     && t.GetInterfaces().Contains(typeof(IAutoServiceRegister)));

        foreach (var serviceType in concreteServiceTypes)
        {
            services.AddScoped(serviceType);
        }

        return services;
    }
}
