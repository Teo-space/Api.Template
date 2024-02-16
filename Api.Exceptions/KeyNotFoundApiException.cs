
/// <summary>
/// Объект не найден. Код 404
/// </summary>
/// <param name="message"></param>
public class KeyNotFoundApiException(string? message) : InvalidOperationApiException(message)
{
}
