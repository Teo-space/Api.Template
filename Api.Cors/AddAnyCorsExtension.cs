using Microsoft.Extensions.DependencyInjection;

public static class AddAnyCorsExtension
{
    public static IServiceCollection AddAnyCors(this IServiceCollection services, string releaseCorsPolicy)
    {
        services.AddCors(options => options.AddPolicy(releaseCorsPolicy, builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));
        return services;
    }
}
