using Api.Template.Interfaces.Repositories;
using Api.Template.Interfaces.Services;
using Api.Template.Models.Output.Basket;

namespace Api.Template.Services.Implementation;

internal sealed record BasketSevice(IBasketSeviceRepository BasketSeviceRepository) : IBasketSevice
{
    public async Task<BasketModel> GetBasketByClient(Guid clientId)
    {
        var basketModel = new BasketModel();

        basketModel.Positions = await BasketSeviceRepository.GetBasketByClient(clientId);

        return basketModel;
    }

}
