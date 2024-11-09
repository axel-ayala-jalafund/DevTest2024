using ApiBackend.Core.src.Application.Services;
using ApiBackend.Core.src.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ApiBackend.Core.src.DependencyInjection;


public static class CoreDependencyInjection
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddServices();        
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPollService, PollService>();
        
        return services;
    }
}
