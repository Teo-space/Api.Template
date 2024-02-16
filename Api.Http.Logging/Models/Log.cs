namespace Api.Http.Logging.Models;

public class Log
{
    public Log(string serviceName) 
    {
        LogId = Ulid.NewUlid().ToGuid();//обеспечивает сортируемый Id
        CreateDate = DateTime.Now;
        ServiceName = serviceName;
    }

    public Guid LogId { get; }
    public string ServiceName { get; set; }
    public DateTime CreateDate { get; set; }

    public string TraceId { get; set; }
    public string ServerIp { get; set; }
    public string ClientIp { get; set; }
    public string FrontServerIp { get; set; }
    public double ExecuteTime { get; set; }


    public RequestInfo Request {  get; set; } = new RequestInfo();

    public ResponseInfo Response { get; set; } = new ResponseInfo();

    public ExceptionInfo Exception { get; set; } = new ExceptionInfo();
}
