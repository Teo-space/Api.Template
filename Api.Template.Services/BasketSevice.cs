using Api.Template.Interfaces.DbContexts;
using Api.Template.Interfaces.Services;
using Api.Template.Models.Output;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Services;

internal class BasketSevice(ISampleDbContext dbContext) : IBasketSevice
{
    public async Task<BasketModel> GetBasketByClient(Guid clientId)
    {
        var basketModel = new BasketModel();

        basketModel.Positions = await dbContext.BasketPositions
            .AsNoTracking()
            .Where(x => x.ClientId == clientId)
            .ProjectToType<BasketPositionModel>()
            .ToListAsync();

        return basketModel;
    }

}
