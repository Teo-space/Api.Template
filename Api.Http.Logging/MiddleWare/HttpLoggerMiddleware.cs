using Api.Http.Logging.Logger;
using Api.Http.Logging.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Api.Http.Logging.MiddleWare;

public class HttpLoggerMiddleware(RequestDelegate next, string serviceName)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        IHttpLogger HttpLogger = httpContext.RequestServices.GetRequiredService<IHttpLogger>();
        Log log = new Log(serviceName);
        HttpRequest request = httpContext.Request;
        log.TraceId = httpContext.TraceIdentifier;
        {
            var httpConnectionFeature = httpContext.Features.Get<Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature>();

            log.ServerIp = httpConnectionFeature?.LocalIpAddress?.ToString();
            if (!string.IsNullOrEmpty(log.ServerIp))
            {
                log.ServerIp = log.ServerIp.Replace("::ffff:", "");
            }

            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                var IdAddresses = httpContext.Request.Headers["X-Forwarded-For"]
                    .Where(x => !string.IsNullOrEmpty(x))
                    .OfType<string>()
                    .ToArray();
                if(IdAddresses is not null && IdAddresses.Any())
                {
                    string pattern = "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

                    log.ClientIp = IdAddresses.FirstOrDefault().Split(',').LastOrDefault(_ => Regex.IsMatch(_, pattern, RegexOptions.IgnoreCase));

                    if (IdAddresses.Length > 1)
                    {
                        log.FrontServerIp = IdAddresses[1];
                    }
                    else
                    {
                        log.FrontServerIp = log.ClientIp;
                    }
                }
            }
            else
            {
                log.ClientIp = httpConnectionFeature?.RemoteIpAddress?.ToString();
                log.FrontServerIp = string.Empty;
            }
        }


        await SetupRequest(log, request);
        await SetupResponce(log, httpContext, httpContext.Response);

        await HttpLogger.WriteLogAsync(log);
    }

    private async Task SetupRequest(Log log, HttpRequest request)
    {
        log.Request.Path = request.Path;
        log.Request.Method = request.Method;
        log.Request.Host = request.Host.ToString();
        log.Request.Headers = string.Join(",\r\n", request.Headers.Select(x => $"[{x.Key}:{x.Value}]"));

        log.Request.Query = request.QueryString.ToString();

        log.Request.ContentType = request.ContentType;
        log.Request.Body = await ReadBodyFromBody(request);
        log.Request.Form = ReadBodyFromForm(request);
    }

    private string ReadBodyFromForm(HttpRequest request)
    {
        try
        {
            if (request.HasFormContentType && request.Form != null && request.Form.Any())
            {
                return string.Join(",\r\n", request.Form.Select(x => $"[{x.Key}:{x.Value.ToString()}]"));
            }
            else return string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }
    private async Task<string> ReadBodyFromBody(HttpRequest request)
    {
        request.EnableBuffering();
        using var streamReader = new StreamReader(request.Body, leaveOpen: true);
        var requestBody = await streamReader.ReadToEndAsync();
        request.Body.Position = 0;
        return requestBody[..Math.Min(requestBody.Length, 5000)];
    }

    private async Task SetupResponce(Log log, HttpContext httpContext, HttpResponse response)
    {
        var originalResponseBody = response.Body;
        using var newResponseBody = new MemoryStream();
        response.Body = newResponseBody;

        var stopwatch = Stopwatch.StartNew();

        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            log.Exception.Message = exception.Message;
            log.Exception.Detail = exception.ToString();
            httpContext.Response.StatusCode = 500;
        }

        stopwatch.Stop();
        log.ExecuteTime = stopwatch.Elapsed.TotalSeconds;

        newResponseBody.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();
        newResponseBody.Seek(0, SeekOrigin.Begin);
        await newResponseBody.CopyToAsync(originalResponseBody);


        log.Response.Status = response.StatusCode;
        log.Response.Headers = string.Join(",\r\n", response.Headers.Select(x => $"[{x.Key}:{x.Value}]"));

        log.Response.ContentType = response.ContentType;
        log.Response.Body = responseBodyText[..Math.Min(responseBodyText.Length, 3000)];
    }
}
