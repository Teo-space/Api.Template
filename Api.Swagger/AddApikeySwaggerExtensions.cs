using Microsoft.OpenApi.Models;

public static class AddApikeySwaggerExtensions
{
    /// <summary>
    /// Add Swagger with ApiKey Auth
    /// </summary>
    /// <param name="services"></param>
    /// <param name="title"></param>
    /// <param name="xmlComments">Path.Combine(AppContext.BaseDirectory, $"File.xml")</param>
    public static IServiceCollection AddApikeySwagger(this IServiceCollection services, string title, params string[] xmlComments)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            foreach (var xmlComment in xmlComments)
            {
                options.IncludeXmlComments(xmlComment, includeControllerXmlComments: true);
            }

            options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });

            options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
            {
                Description = "ApiKey must appear in header",
                Type = SecuritySchemeType.ApiKey,
                Name = "X-API-KEY",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme"
            });
            var key = new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                },
                In = ParameterLocation.Header
            };
            var requirement = new OpenApiSecurityRequirement
            {
                        { key, new List<string>() }
            };
            options.AddSecurityRequirement(requirement);
        });
        return services;
    }
}
