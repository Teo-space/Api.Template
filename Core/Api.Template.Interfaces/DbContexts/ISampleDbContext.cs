using Api.Template.Domain.Models.Basket;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Interfaces.DbContexts;

public interface ISampleDbContext
{
    DbSet<BasketPosition> BasketPositions { get; }
}
