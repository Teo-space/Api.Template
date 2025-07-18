using Api.Template.Infrastructure.EntityFramework.DbContexts;
using Api.Template.Infrastructure.Repositories;
using Api.Template.Interfaces.Repositories;
using Microsoft.Extensions.Hosting;

namespace Api.Template.Infrastructure;

public static class DI
{
    public static void AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<SampleDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString(DbConnectionNames.Connection)));

        builder.Services.AddScoped<IBasketSeviceRepository, BasketSeviceRepository>();



    }

}
