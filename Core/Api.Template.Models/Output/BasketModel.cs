namespace Api.Template.Models.Output;

/// <summary>
/// Корзина
/// </summary>
public class BasketModel
{
    /// <summary>
    /// Позиции
    /// </summary>
    public IReadOnlyCollection<BasketPositionModel> Positions { get; set; } = new List<BasketPositionModel>();
}
