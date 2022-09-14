using Microsoft.Extensions.Configuration;

namespace Oig.AppConfiguration.Extensions;

public static class ConfigurationManagerExtensions
{
    public static void AddApplicationConfiguration(this ConfigurationManager configurationManager)
    {
        configurationManager.AddAzureAppConfiguration(configurationManager);

        // configurationManager.ApplyGlobalGroupSettingsAppConfiguration();
        //
        // configurationManager.ApplyGlobalSettingsAppConfiguration();
        //
        // configurationManager.ApplyRootSettingsConfiguration();
    }
}
