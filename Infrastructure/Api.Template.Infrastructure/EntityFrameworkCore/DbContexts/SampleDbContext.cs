using Api.Template.Domain.Models.Basket;
using Api.Template.Interfaces.DbContexts;

namespace Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;

public class SampleDbContext(DbContextOptions<SampleDbContext> options) : DbContext(options), ISampleDbContext
{
    public DbSet<BasketPosition> BasketPositions { get; set; }

#if DEBUG
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(Console.WriteLine, minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information);
    }
#endif

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}