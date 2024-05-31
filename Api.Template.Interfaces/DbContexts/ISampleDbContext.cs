using Api.Template.Domain.Basket;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Interfaces.DbContexts;

public interface ISampleDbContext
{
    DbSet<BasketPosition> BasketPositions { get; }
}
