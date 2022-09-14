using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OIG.Survey.Data.Database.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection serviceCollection, DataSettings dataSettings)
        => serviceCollection.AddDbContext<DataDbContext>(options =>
            options.UseNpgsql(dataSettings.ConnectionString));
}