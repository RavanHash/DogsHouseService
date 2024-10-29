using Dogshouseservice.Application.Dogs.Common;
using ErrorOr;
using MediatR;

namespace Dogshouseservice.Application.Dogs.Commands.AddDog;

public record AddDogCommand(
    string Name,
    string Color,
    int TailLength,
    int Weight) : IRequest<ErrorOr<DogsResult>>;