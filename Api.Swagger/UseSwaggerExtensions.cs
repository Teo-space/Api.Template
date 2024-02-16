using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Api.Swagger;

public static class UseSwaggerExtensions
{
    /// <summary>
    /// использовать Swagger с префиксом
    /// так же нужно в отладке настроить запуск Prefix/Swagger
    /// при этом создается Properties/launchSettings.json
    /// </summary>
    /// <param name="app"></param>
    /// <param name="serviceName"></param>
    /// <param name="routePrefix"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseSwaggerWithRoute(this IApplicationBuilder app, string serviceName, string routePrefix = null)
    {
        if (string.IsNullOrEmpty(routePrefix))
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseSwagger(c =>
                c.RouteTemplate = $"{routePrefix}/{{documentName}}/swagger.json"
            );
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/{routePrefix}/v1/swagger.json", serviceName);
                c.RoutePrefix = $"{routePrefix}/swagger";
            });
        }

        return app;
    }


}
