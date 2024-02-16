using Api.Controllers;
using Api.Template.Models.Input;
using Api.Template.Models.Output;
using Api.Template.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Template.Rest.Controllers;

/// <summary>
/// Корзина покупателя
/// </summary>
[Route($"{Prefix}/[controller]")]//Override route if needed
public class BasketController(ILogger<BasketController> logger, IBasketSevice basketSevice) 
    : ApiBaseController
{
    /// <summary>
    /// получить корзину клиента
    /// </summary>
    [HttpGet]
    [Produces(typeof(BasketModel))]
    public async Task<IActionResult> GetBasketByClient([FromQuery] GetBasketPositionsInput input)
    {
        var result = await basketSevice.GetBasketByClient(input.СlientId);
        return Ok(result);
    }
}
