using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Domain.Dogs;
using MediatR;

namespace Dogshouseservice.Application.Dogs.Queries.GetDogs;

public class GetDogsQueryHandler(IDogsRepository dogsRepository) : IRequestHandler<GetDogsQuery, List<Dog>>
{
    public async Task<List<Dog>> Handle(
        GetDogsQuery request,
        CancellationToken cancellationToken)
    {
        return await dogsRepository.GetDogsAsync(
            request.PageNumber,
            request.PageSize,
            request.Attribute,
            request.Order);
    }
}