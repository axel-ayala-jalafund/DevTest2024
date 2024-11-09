using ApiBackend.Core.src.Domain.Interfaces.Repositories;
using ApiBackend.Infraestructure.src.Data.DbConnection;
using ApiBackend.Infraestructure.src.Data.DbConnection.Concrete;
using ApiBackend.Infraestructure.src.Data.DbConnection.Interfaces;
using ApiBackend.Infraestructure.src.Data.Memory;
using ApiBackend.Infraestructure.src.Repositories.BaseMemoryRepository;
using ApiBackend.Infraestructure.src.Repositories.DbRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiBackend.Infraestructure.src.DependencyInjection;

public static class InfraestructureDependencyInjection
{
    public static IServiceCollection AddInfraestructureLayer(
        this IServiceCollection services,
        IConfiguration configuration,
        bool useMemoryStorage = false
        )
    {
        if (useMemoryStorage)
        {
            services.AddMemoryStorage();
        }
        else
        {
            services.AddDataBase(configuration);
        }

        services.AddRepositories(useMemoryStorage);

        return services;
    }

    private static IServiceCollection AddRepositories(
        this IServiceCollection services,
        bool useMemoryStorage
    ) 
    {
        if (useMemoryStorage)
        {
            services.AddScoped<IPollRepository, PollMemoryRepository>();
        }
        else 
        {
            services.AddScoped<IPollRepository, PollRepository>();
        }

        return services;
    }

    private static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.ConnectionStrings));
        services.AddScoped<IDbConnectionFactory, DbConnection>();
        return services;
    }

    private static IServiceCollection AddMemoryStorage(this IServiceCollection services)
    {
        services.AddSingleton<MemoryContext>();

        return services;
    }
}
