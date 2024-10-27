namespace Dogshouseservice.Contracts.Dogs;

public record AddDogRequest(
    string Name,
    string Color,
    int TailLength,
    int Weight);