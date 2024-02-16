using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

public static class AddFluentValidationWithValidatorsExtensions
{
    public static IServiceCollection AddFluentValidationWithValidators(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddFluentValidationAutoValidation(cf => { cf.DisableDataAnnotationsValidation = true; })
            .AddFluentValidationClientsideAdapters();
        foreach(var assembly in assemblies)
        {
            services.AddValidatorsFromAssembly(assembly);
        }
        
        services.AddFluentValidationRulesToSwagger();

        return services;
    }
}
