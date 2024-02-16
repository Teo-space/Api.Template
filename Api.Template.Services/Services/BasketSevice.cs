using Api.Template.Infrastructure.EntityFrameworkCore.DbContexts;
using Api.Template.Models.Output;
using Api.Template.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Api.Template.Services.Services;

internal class BasketSevice(SampleDbContext dbContext) : IBasketSevice
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
