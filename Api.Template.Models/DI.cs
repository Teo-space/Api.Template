#pragma warning disable 1591
public static class DI
{
    public static void AddModelsValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
