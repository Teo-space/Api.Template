using Api.Http.Logging.Models;

namespace Api.Http.Logging.Logger;

public interface IHttpLogger
{
    public Task WriteLogAsync(Log log);
}
