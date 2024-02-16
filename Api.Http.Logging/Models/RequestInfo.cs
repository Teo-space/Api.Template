namespace Api.Http.Logging.Models;

public class RequestInfo
{
    public string Path { get; set; }
    public string Method { get; set; }
    public string Host { get; set; }
    public string Headers { get; set; }

    public string ContentType { get; set; }
    public string Query { get; set; }
    public string Body { get; set; }
    public string Form { get; set; }
}
