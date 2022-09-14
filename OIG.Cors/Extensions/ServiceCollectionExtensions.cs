using Microsoft.Extensions.DependencyInjection;

namespace Oig.Cors.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCorsPolicySupport(this IServiceCollection serviceCollection, CorsSettings corsSettings)
    {
        serviceCollection.AddCors(setupAction =>
        {
            setupAction.AddDefaultPolicy(configurePolicy =>
            {
                configurePolicy.WithOrigins(corsSettings.Origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
    }
}
