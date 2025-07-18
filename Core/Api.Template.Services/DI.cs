namespace Api.Template.Services;

using Api.Template.Interfaces.Services;
using Api.Template.Services.Implementation;
using Microsoft.Extensions.Hosting;

public static class DI
{
    public static void AddServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();

        builder.Services.AddScoped<IBasketSevice, BasketSevice>();


    }
}