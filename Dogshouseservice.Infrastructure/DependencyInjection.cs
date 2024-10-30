﻿using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Infrastructure.Common;
using Dogshouseservice.Infrastructure.Dogs.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dogshouseservice.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDogsRepository, DogRepository>();
        services.AddScoped<IVersionService, VersionService>();

        return services;
    }
}