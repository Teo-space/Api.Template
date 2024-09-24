using Api.Controllers;
using Api.Template.Interfaces.Services;
using Api.Template.Models.Input;
using Api.Template.Models.Output;
using Microsoft.AspNetCore.Mvc;

namespace Api.Template.Rest.Controllers;

/// <summary>
/// ������� ����������
/// </summary>
[Route($"{Prefix}/[controller]")]
public class BasketController(ILogger<BasketController> logger, IBasketSevice basketSevice) 
    : ApiBaseController
{
    /// <summary>
    /// �������� ������� �������
    /// </summary>
    [HttpGet]
    [Produces(typeof(BasketModel))]
    public async Task<IActionResult> GetBasketByClient([FromQuery] GetBasketPositionsInput input)
    {
        var result = await basketSevice.GetBasketByClient(input.ClientId);
        return Ok(result);
    }
}
