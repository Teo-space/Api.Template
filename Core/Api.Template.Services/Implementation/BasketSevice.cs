using Api.Template.Interfaces.DbContexts;
using Api.Template.Interfaces.Services;
using Api.Template.Models.Output.Basket;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Services.Implementation;

internal sealed record BasketSevice(ISampleDbContext DbContext) : IBasketSevice
{
    public async Task<BasketModel> GetBasketByClient(Guid clientId)
    {
        var basketModel = new BasketModel();

        basketModel.Positions = await DbContext.BasketPositions
            .AsNoTracking()
            .Where(x => x.ClientId == clientId)
            .ProjectToType<BasketPositionModel>()
            .ToListAsync();

        return basketModel;
    }

}
