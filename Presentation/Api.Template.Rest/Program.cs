using Api.Filters.Filters;
using Api.Template.Infrastructure;
using Api.Template.Services;

var builder = WebApplication.CreateBuilder(args);

string ReleaseCorsPolicy = "ReleaseCorsPolicy";

{
    builder.Services.AddAnyCors(ReleaseCorsPolicy);
    builder.Services.AddControllersWithFilters(typeof(HttpExceptionFilter));

    builder.AddSerilogLogging("Api.Template");

    builder.Services.AddFluentValidationWithValidators();
    builder.Services.AddModelsValidation();

    string appBasePath = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)
        ?? throw new Exception("appBasePath is null");

    builder.Services.AddDefaultSwagger("Api.Template",
        Path.Combine(appBasePath, $"Api.Template.Rest.xml"),
        Path.Combine(appBasePath, $"Api.Template.Models.xml"));
}
{
    builder.AddInfrastructure();
    builder.AddServices();
}
var app = builder.Build();
{
    app.UseSwaggerWithRoute("Api.Template", Route.Prefix);
    app.UseCors(ReleaseCorsPolicy);

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

