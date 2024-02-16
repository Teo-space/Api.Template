namespace Api.Exceptions;

/// <summary>
/// Ошибка ограничений бизнес логики. Код 409
/// </summary>
/// <param name="message"></param>
public class InvalidConstraintApiException(string? message) : InvalidOperationApiException(message)
{
}
