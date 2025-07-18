using Api.Controllers;
using Api.Template.Interfaces.Services;
using Api.Template.Models.Input;
using Api.Template.Models.Output.Basket;
using Microsoft.AspNetCore.Mvc;

namespace Api.Template.Rest.Controllers;

/// <summary>
/// Корзина
/// </summary>
[Route($"{Prefix}/[controller]")]
public class BasketController(ILogger<BasketController> logger, IBasketSevice basketSevice)
    : ApiBaseController
{
    /// <summary>
    /// получить корзину клиента
    /// </summary>
    [HttpGet, Produces(typeof(BasketModel))]
    public async Task<ActionResult> GetBasketByClient([FromQuery] GetBasketPositionsInput input)
        => await basketSevice.GetBasketByClient(input.ClientId);

}
