﻿namespace Api.Template.Services;

using Api.Template.Services.Interfaces;
using Api.Template.Services.Services;
using Microsoft.Extensions.Configuration;


public static class DI
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();

        services.AddScoped<IBasketSevice, BasketSevice>();


    }
}