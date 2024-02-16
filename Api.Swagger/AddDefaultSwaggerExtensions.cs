using Microsoft.OpenApi.Models;

public static class AddDefaultSwaggerExtensions
{
    /// <summary>
    /// Add Swagger with ApiKey Auth
    /// </summary>
    /// <param name="services"></param>
    /// <param name="title"></param>
    /// <param name="xmlComments">Path.Combine(AppContext.BaseDirectory, $"File.xml")</param>
    public static IServiceCollection AddDefaultSwagger(this IServiceCollection services, string title, params string[] xmlComments)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            foreach (var xmlComment in xmlComments)
            {
                options.IncludeXmlComments(xmlComment, includeControllerXmlComments: true);
            }

            options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });
        });
        return services;
    }
}
