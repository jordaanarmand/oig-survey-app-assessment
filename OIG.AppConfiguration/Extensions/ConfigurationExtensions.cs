using Microsoft.Extensions.Configuration;
using static Oig.AppConfiguration.Constants;

namespace Oig.AppConfiguration.Extensions;

public static class ConfigurationExtensions
{
    // TODO: Add Appconfiguration support
    public static string GetAzureAppConfigurationConnectionString(this IConfiguration configuration)
        => configuration.GetValue<string>(RootSettingsConstants.AzureAppConfigurationConnectionString);

    public static IConfigurationSection GetSection<TSettings>(this IConfiguration configuration)
        => configuration
            .GetSection(typeof(TSettings).Name);

    public static TSettings GetSettings<TSettings>(this IConfiguration configuration)
        => configuration
            .GetSection<TSettings>()
            .Get<TSettings>();
}