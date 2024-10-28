namespace Dogshouseservice.Application.Dogs.Common;

public record DogsResult(
    string Name,
    string Color,
    int TailLength,
    int Weight);