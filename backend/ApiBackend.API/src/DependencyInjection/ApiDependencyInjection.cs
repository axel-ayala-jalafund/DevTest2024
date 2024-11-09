using ApiBackend.API.src.Validators;
using ApiBackend.Core.src.Application.DTO;
using FluentValidation;

namespace ApiBackend.API.src.DependencyInjection;

public static class ApiDependencyInjection
{
    public static IServiceCollection AddApiLayer(this IServiceCollection services)
    {
        services.AddValidators();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreatePollDto>, CreatePollValidator>();
        services.AddScoped<IValidator<CreateVoteDto>, CreateVoteValidator>();
   
        return services;
    }
}
