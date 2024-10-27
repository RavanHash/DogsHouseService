namespace Dogshouseservice.Contracts.Dogs;

public record DogResponse(
    string Name,
    string Color,
    int TailLength,
    int Weight);