using System.Text.Json.Serialization;
using ApiBackend.API.src.DependencyInjection;
using ApiBackend.Core.src.DependencyInjection;
using ApiBackend.Infraestructure.src.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace ApiBackend.API.src;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder.Services, builder.Configuration);
        var app = builder.Build();

        ConfigureMiddlewares(app);
        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddApiLayer()
            .AddCoreLayer()
            .AddInfraestructureLayer(configuration, true);

        services
            .AddControllers()
            .AddJsonOptions(options => {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

        services.AddFluentValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c => {
            c.SwaggerDoc("v1", new OpenApiInfo{
                Title = "BACKEND API",
                Version = "v1",
                Description = "DEV TEST"
            }); 
        });

        services.AddCors(options => {
            options.AddPolicy("AllowAll", builder => {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    private static void ConfigureMiddlewares(WebApplication app) 
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BACKEND API");
            c.RoutePrefix = "swagger";
        });

        app.UseCors("AllowAll");
        app.UseHttpsRedirection();

        app.MapControllers();
    }
}
