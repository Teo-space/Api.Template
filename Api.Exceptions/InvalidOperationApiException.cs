/// <summary>
/// Ошибка клиента. Код 400
/// </summary>
/// <param name="message"></param>
public class InvalidOperationApiException(string? message) : ApiException(message)
{
}
