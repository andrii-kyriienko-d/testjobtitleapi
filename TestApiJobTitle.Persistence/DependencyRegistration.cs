using Microsoft.Extensions.DependencyInjection;
using TestApiJobTitle.Common.Interfaces.Repositories;
using TestApiJobTitle.Persistence.Repositories;

namespace TestApiJobTitle.Persistence;

public static class DependencyRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IJobTitleRepository, JobTitleRepository>();
        
        return services;
    }
}