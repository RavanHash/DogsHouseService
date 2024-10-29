using Dogshouseservice.Domain.Dogs;
using MediatR;

namespace Dogshouseservice.Application.Dogs.Queries.GetDogs;

public record GetDogsQuery(
    int? PageNumber,
    int? PageSize,
    string? Attribute,
    string? Order) : IRequest<List<Dog>>;