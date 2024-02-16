using Api.Http.Logging.Models;

namespace Api.Http.Logging.Logger;

internal class ConsoleHttpLogger : IHttpLogger
{
    public async Task WriteLogAsync(Log log)
    {
        Console.WriteLine(
@$"
* LogId :: {log.LogId}
* ServiceName :: {log.ServiceName}
* CreateDate :: {log.CreateDate}

* ServerIp :: {log.ServerIp}
* ClientIp :: {log.ClientIp}
* FrontServerIp :: {log.FrontServerIp}

* ExecuteTime :: {log.ExecuteTime}

* Request.Path :: {log.Request.Path}
* Request.Method :: {log.Request.Method}
* Request.Host :: {log.Request.Host}
* Request.Headers :: {log.Request.Headers}
* Request.ContentType :: {log.Request.ContentType}
* Request.Query :: {log.Request.Query}
* Request.Body :: {log.Request.Body}
* Request.Form :: {log.Request.Form}

* Response.Status :: {log.Response.Status}
* Response.Headers :: {log.Response.Headers}
* Response.ContentType :: {log.Response.ContentType}
* Response.Body :: {log.Response.Body}

* Exception.Message :: {log.Exception.Message}
* Exception.Detail :: {log.Exception.Detail}
");
    }
}
