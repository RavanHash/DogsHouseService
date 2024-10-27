namespace Dogshouseservice.Application.Services.Dogs;

public record DogsResult(
    string Name,
    string Color,
    int TailLength,
    int Weight);