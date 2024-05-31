using Api.Template.Domain.Basket;
using Api.Template.Interfaces.DbContexts;

namespace Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;

public class SampleDbContext : DbContext, ISampleDbContext
{
    public DbSet<BasketPosition> BasketPositions { get; set; }



    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

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