namespace Api.Http.Logging.Models;

public class ResponseInfo
{
    public int Status { get; set; }
    public string Headers { get; set; }
    public string ContentType { get; set; }
    public string Body { get; set; }
}
