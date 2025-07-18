namespace Api.Template.Models.Output.Basket;

/// <summary>
/// Корзина
/// </summary>
public sealed record BasketModel : OutputModel
{
    /// <summary>
    /// Позиции
    /// </summary>
    public IReadOnlyCollection<BasketPositionModel> Positions { get; set; } = new List<BasketPositionModel>();
}
