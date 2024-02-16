
/// <summary>
/// Базовая ошибка апи
/// </summary>
/// <param name="message"></param>
public class ApiException(string? message) : Exception(message)
{
}
