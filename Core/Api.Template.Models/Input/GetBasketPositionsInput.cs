namespace Api.Template.Models.Input;

/// <summary>
/// Вх. модель для позиций корзины покупателя
/// </summary>
public class GetBasketPositionsInput
{
    /// <summary>
    /// ID клиента
    /// </summary>
    public Guid ClientId { get; set; }


    public class Validator : AbstractValidator<GetBasketPositionsInput>
    {
        public Validator()
        {
            RuleFor(x => x.ClientId).NotEmpty();
        }
    }
}
