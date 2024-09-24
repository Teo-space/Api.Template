namespace Api.Template.Domain.Models.Basket;


[Table("BASKET_POSITION"),
    PrimaryKey(nameof(ClientId), nameof(ProductVariantId)),
    Index(nameof(ClientId))]
public class BasketPosition
{
    /// <summary>
    /// ID покупателя
    /// </summary>
    [Column("CLIENT_ID")]
    public Guid ClientId { get; set; }
    /// <summary>
    /// Ид. типа продукта
    /// </summary>
    [Column("PRODUCT_TYPE_ID")]
    public Guid ProductTypeId { get; set; }

    /// <summary>
    /// Ид. продукта
    /// </summary>
    [Column("PRODUCT_ID")]
    public Guid ProductId { get; set; }

    /// <summary>
    /// Ид. варианта продукта
    /// </summary>
    [Column("PRODUCT_VARIANT_ID")]
    public Guid ProductVariantId { get; set; }

    /// <summary>
    /// наименование
    /// </summary>
    [Column("PRODUCT_VARIANT_NAME")]
    public string ProductVariantName { get; set; }

    /// <summary>
    /// количество
    /// </summary>
    [Column("QUANITY")]
    public int Quanity { get; set; }

}
