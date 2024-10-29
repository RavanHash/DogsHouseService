namespace Dogshouseservice.Infrastructure.Common;

public record RateLimitingOptions(int Window, int PermitLimit);