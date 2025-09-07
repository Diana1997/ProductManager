using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManager.Application._Common.Interfaces;
using ProductManager.Application._Common.Services;
using ProductManager.Infrastructure;

namespace ProductManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        

        services.Scan(scan => scan
            .FromApplicationDependencies() 
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.Scan(scan => scan
            .FromApplicationDependencies() 
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        return services;
    }
}