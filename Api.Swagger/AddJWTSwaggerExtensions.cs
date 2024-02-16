using Microsoft.OpenApi.Models;

public static class AddJWTSwaggerExtensions
{
    /// <summary>
    /// Add Swagger with Bearer JWT
    /// </summary>
    /// <param name="services"></param>
    /// <param name="title"></param>
    /// <param name="xmlComments">Path.Combine(AppContext.BaseDirectory, $"File.xml")</param>
    public static IServiceCollection AddJWTSwagger(this IServiceCollection services, string title, params string[] xmlComments)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1" });

            foreach (var xmlComment in xmlComments)
            {
                options.IncludeXmlComments(xmlComment, includeControllerXmlComments: true);
            }

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
        return services;
    }
}
