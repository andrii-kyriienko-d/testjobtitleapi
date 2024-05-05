using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TestApiJobTitle.Common.Options;
using TestApiJobTitle.Core.MappingProfiles;
using TestApiJobTitle.Persistence;
using TestApiJobTitle.Persistence.Database;
using TestApiJobTitle.Services;

namespace TestApiJobTitle.Core.Extensions;

public static class DependencyRegistrationExtensions
{
    public static IServiceCollection AddTestApiJobTitle(this IServiceCollection services,
        ConfigurationManager builderConfiguration)
    {
        services.AddOptions(builderConfiguration);
        services.AddDbContexts();
        services.AddRepositories();
        services.AddServices();
        services.AddAutoMapper(typeof(JobTitleProfile));
        
        return services;
    }

    private static void AddOptions(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<DatabaseOptions>(
            configuration.GetSection(nameof(DatabaseOptions)));
    }

    private static void AddDbContexts(this IServiceCollection services)
    {
        services.AddDbContextPool<JobTitleDbContext>((serviceProvider, builder) =>
        {
            var databaseOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
            builder.UseNpgsql(databaseOptions.Value.ConnectionString);
        });
    }
}