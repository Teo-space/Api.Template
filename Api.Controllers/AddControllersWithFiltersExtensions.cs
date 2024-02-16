using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

public static class AddControllersWithFiltersExtensions
{
    public static IServiceCollection AddControllersWithFilters(this IServiceCollection services, params Type[] filters)
    {
        services.AddControllers(options =>
        {
            filters.ToList().ForEach(x => options.Filters.Add(x));
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                var validationDetails = actionContext.ModelState
                    .Where(modelError => modelError.Value != null && modelError.Value.Errors.Any())
                    .Select(modelError => new FieldError()
                    {
                        FieldName = modelError.Key,
                        ErrorMessages = modelError.Value!.Errors.Select(x => x.ErrorMessage).ToArray()
                    }).ToArray();

                var result = Results.Errors<HttpStatusCode>(HttpStatusCode.BadRequest.ToString(), "ValidationErrors", validationDetails);

                return new BadRequestObjectResult(result);
            };
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.MaxDepth = 10;
            options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
        });

        return services;
    }


}
