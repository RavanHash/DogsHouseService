using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Infrastructure.Dogs.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Dogshouseservice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDogsRepository, DogRepository>();

        return services;
    }
}