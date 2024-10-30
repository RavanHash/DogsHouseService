using Dogshouseservice.Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Dogshouseservice.Infrastructure.Common;

public class VersionService(IConfiguration configuration) : IVersionService
{
    public string? GetVersion()
    {
        return configuration["ServiceInfo:Version"];
    }
}