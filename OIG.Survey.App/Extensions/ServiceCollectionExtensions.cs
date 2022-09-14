namespace OIG_Survey_App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddFrontEnd(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(typeof(Program));
    }
}