using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Interfaces.DbContexts;
using Microsoft.Extensions.Hosting;

namespace Api.Template.Infrastructure;

public static class DI
{
    public static void AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<SampleDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString(DbConnectionNames.Connection)));

        builder.Services.AddScoped<ISampleDbContext, SampleDbContext>();



    }

}
