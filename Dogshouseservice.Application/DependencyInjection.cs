using Dogshouseservice.Application.Services.Dogs;
using Microsoft.Extensions.DependencyInjection;

namespace Dogshouseservice.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDogsService, DogsService>();

        return services;
    }
}