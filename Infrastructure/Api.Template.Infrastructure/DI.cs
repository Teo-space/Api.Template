using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Interfaces.DbContexts;

namespace Api.Template.Infrastructure;

public static class DI
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SampleDbContext>(options => options
        .UseSqlServer(configuration.GetConnectionString(DbConnectionNames.Connection)));

        services.AddScoped<ISampleDbContext, SampleDbContext>();



    }

}
