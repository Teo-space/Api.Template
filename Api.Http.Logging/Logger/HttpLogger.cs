using Api.Http.Logging.Models;
using Microsoft.Extensions.Logging;

namespace Api.Http.Logging.Logger;

internal class HttpLogger(ILogger<HttpLogger> logger) : IHttpLogger
{
    public async Task WriteLogAsync(Log log)
    {
        logger.LogWarning(
@"
* LogId :: {LogId}
* ServiceName :: {ServiceName}
* CreateDate :: {CreateDate}

* ServerIp :: {ServerIp}
* ClientIp :: {ClientIp}
* FrontServerIp :: {FrontServerIp}

* ExecuteTime :: {ExecuteTime}

* Request.Path :: {Path}
* Request.Method :: {Method}
* Request.Host :: {Host}
* Request.Headers :: {Headers}
* Request.ContentType :: {ContentType}
* Request.Query :: {Query}
* Request.Body :: {Body}
* Request.Form :: {Form}

* Response.Status :: {Status}
* Response.Headers :: {Headers}
* Response.ContentType :: {.ContentType}
* Response.Body :: {Body}

* Exception.Message :: {Message}
* Exception.Detail :: {Detail}
",
log.LogId,
log.ServiceName,
log.CreateDate,
log.TraceId,
log.ServerIp,
log.ClientIp,
log.ExecuteTime,

log.Request.Path,
log.Request.Method,
log.Request.Host,
log.Request.Headers,
log.Request.ContentType,
log.Request.Query,
log.Request.Body,
log.Request.Form,

log.Response.Status,
log.Response.Headers,
log.Response.ContentType,
log.Response.Body,

log.Exception.Message,
log.Exception.Detail);

    }
}
