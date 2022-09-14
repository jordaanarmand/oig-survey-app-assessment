using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Oig.AppConfiguration.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureSettings<TSettings>(this IServiceCollection serviceCollection, IConfiguration configuration)
        where TSettings : class
        => serviceCollection.Configure<TSettings>(configuration.GetSection<TSettings>());
}