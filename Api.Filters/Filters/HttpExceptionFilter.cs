using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using Api.Exceptions;

namespace Api.Filters.Filters;


public class HttpExceptionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue;

    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<HttpExceptionFilter>>();

        if (context?.Exception is not null)
        {
            var exception = context.Exception;
            var exceptionType = exception.GetType().Name;
            var status = exception switch
            {
                //Пользователь авторизован, но нет прав для выполнения операции
                UnauthorizedAccessException => HttpStatusCode.Forbidden,

                //Объект не найден.
                KeyNotFoundApiException => HttpStatusCode.NotFound,

                //Ошибка ограничений бизнес логики.
                InvalidConstraintApiException => HttpStatusCode.Conflict,

                //Ошибка клиента
                InvalidOperationApiException => HttpStatusCode.BadRequest,


                Exception => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.InternalServerError,
            };


            context.ExceptionHandled = true;

            if (status == HttpStatusCode.InternalServerError)
            {
                context.Result = new JsonResult(Results.Problem(status, exceptionType, string.Empty))//не выводим неожиданные ошибки на фронт
                {
                    StatusCode = (int)status
                };
                logger.LogError(exception, $"Произошла ошибка {{Exception}} {{Message}}", exceptionType, exception.Message);
            }
            else if (status == HttpStatusCode.BadRequest)
            {
                context.Result = new JsonResult(Results.Problem(status, exceptionType, exception.Message))
                {
                    StatusCode = (int)status
                };
                logger.LogWarning(exception, $"Произошла ошибка {{Exception}} {{Message}}", exceptionType, exception.Message);
            }
            else
            {
                context.Result = new JsonResult(Results.Problem<HttpStatusCode>(status.ToString(), exception.Message))
                {
                    StatusCode = (int)status
                };

                logger.LogWarning(exception, $"Произошла ошибка {{Exception}} {{Message}}", exceptionType, exception.Message);
            }
        }
    }
}