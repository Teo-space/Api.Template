using Api.Controllers;
using Api.Filters.Filters;
using Api.Swagger;
using Api.Template.Infrastructure;
using Api.Template.Services;


var builder = WebApplication.CreateBuilder(args);
string ReleaseCorsPolicy = "ReleaseCorsPolicy";
{
    //builder.Services.AddControllers();
    builder.Services.AddControllersWithFilters(typeof(HttpExceptionFilter));
    builder.Services.AddAnyCors(ReleaseCorsPolicy);
    builder.Logging.AddSerilogLogging(builder.Configuration);
    builder.Services.AddMemoryCache();
    builder.Services.AddFluentValidationWithValidators();
    builder.Services.AddModelsValidation();

    var AppBasePath = builder.Configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
    AppBasePath += Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar;

    builder.Services.AddDefaultSwagger("Api.Template",
        Path.Combine(AppBasePath, /*AppContext.BaseDirectory,*/ $"Api.Template.Rest.xml"));
}
{
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddServices(builder.Configuration);
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

