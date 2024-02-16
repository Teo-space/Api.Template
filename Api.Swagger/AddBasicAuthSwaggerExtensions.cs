using Microsoft.OpenApi.Models;

public static class AddBasicAuthSwaggerExtensions
{
    /// <summary>
    /// Add Swagger with ApiKey Auth
    /// </summary>
    /// <param name="services"></param>
    /// <param name="title"></param>
    /// <param name="xmlComments">Path.Combine(AppContext.BaseDirectory, $"File.xml")</param>
    public static IServiceCollection AddBasicAuthSwagger(this IServiceCollection services, string title, params string[] xmlComments)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            foreach (var xmlComment in xmlComments)
            {
                options.IncludeXmlComments(xmlComment, includeControllerXmlComments: true);
            }

            options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });

            options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "basic authentication for API"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        }
                    },
                    new string[] {}
                }
            });

        });
        return services;
    }
}
