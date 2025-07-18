using Api.Template.Infrastructure.EntityFramework.DbContexts;
using Api.Template.Interfaces.Repositories;
using Api.Template.Models.Output.Basket;
using Mapster;

namespace Api.Template.Infrastructure.Repositories;

internal sealed record BasketSeviceRepository(SampleDbContext SampleDbContext) : IBasketSeviceRepository
{
    public async Task<IReadOnlyCollection<BasketPositionModel>> GetBasketByClient(Guid clientId)
    {
        return await SampleDbContext.BasketPositions
            .AsNoTracking()
            .Where(x => x.ClientId == clientId)
            .ProjectToType<BasketPositionModel>()
            .ToListAsync();
    }
}
