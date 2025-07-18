using Api.Template.Models.Output.Basket;

namespace Api.Template.Interfaces.Repositories;

public interface IBasketSeviceRepository
{
    Task<IReadOnlyCollection<BasketPositionModel>> GetBasketByClient(Guid clientId);
}
