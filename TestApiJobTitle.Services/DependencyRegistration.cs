using Microsoft.Extensions.DependencyInjection;
using TestApiJobTitle.Common.Interfaces.Services;
using TestApiJobTitle.Services.Services;

namespace TestApiJobTitle.Services;

public static class DependencyRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IJobTitleService, JobTitleService>();
        
        return services;
    }
}