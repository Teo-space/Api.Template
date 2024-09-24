using Api.Template.Models.Output;

namespace Api.Template.Interfaces.Services;

/// <summary>
/// Корзина
/// </summary>
public interface IBasketSevice
{
    /// <summary>
    /// получить корзину клиента
    /// </summary>
    public Task<BasketModel> GetBasketByClient(Guid clientId);



}
