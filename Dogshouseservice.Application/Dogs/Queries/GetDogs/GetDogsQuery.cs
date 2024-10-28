using Dogshouseservice.Domain.Dogs;
using MediatR;

namespace Dogshouseservice.Application.Dogs.Queries.GetDogs;

public record GetDogsQuery() : IRequest<List<Dog>>;