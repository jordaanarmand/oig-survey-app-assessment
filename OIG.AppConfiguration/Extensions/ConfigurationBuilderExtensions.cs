using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace Oig.AppConfiguration.Extensions;
// https://docs.microsoft.com/en-us/azure/azure-app-configuration/howto-integrate-azure-managed-service-identity?tabs=core5x&pivots=framework-dotnet

public static class ConfigurationBuilderExtensions
{
    public static void AddAzureAppConfiguration(this IConfigurationBuilder configurationBuilder, IConfiguration configuration)
    {
        // Override initial app settings with settings retrieved from Azure App Configuration for current environment
        configurationBuilder.AddAzureAppConfiguration(options =>
        {
            // Initial app settings contain the connection string for Azure App Configuration
            // This is for SAMI else you'd need to specify a "clientId" as param to ManagedIdentityCredential to use UAMI
            options
                .Connect(new Uri(configuration.GetAzureAppConfigurationConnectionString()), new ManagedIdentityCredential())
                .Select("*");
        });
    }
}
