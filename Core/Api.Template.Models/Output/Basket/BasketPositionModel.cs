namespace Api.Template.Models.Output.Basket;

/// <summary>
/// Позиция
/// </summary>
public sealed record BasketPositionModel
{
    /// <summary>
    /// ID покупателя
    /// </summary>
    public Guid ClientId { get; set; }
    /// <summary>
    /// Ид. типа продукта
    /// </summary>
    public Guid ProductTypeId { get; set; }

    /// <summary>
    /// Ид. продукта
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Ид. варианта продукта
    /// </summary>
    public Guid ProductVariantId { get; set; }

    /// <summary>
    /// наименование
    /// </summary>
    public string ProductVariantName { get; set; }

    /// <summary>
    /// количество
    /// </summary>
    public int Quanity { get; set; }
}
