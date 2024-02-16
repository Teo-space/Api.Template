using Api.Template.Domain.Basket;

namespace Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;

public class SampleDbContext : DbContext
{
    public DbSet<BasketPosition> BasketPositions { get; set; }



    public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}