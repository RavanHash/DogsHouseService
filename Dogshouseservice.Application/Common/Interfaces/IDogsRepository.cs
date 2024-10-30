using Dogshouseservice.Domain.Dogs;

namespace Dogshouseservice.Application.Common.Interfaces;

public interface IDogsRepository
{
    Task AddAsync(Dog dog);
    Task<List<Dog>> GetAllAsync();
    Task<bool> ExistsAsync(string name);

    Task<List<Dog>> GetDogsAsync(
        int? pageNumber,
        int? pageSize,
        string? attribute,
        string? order);
}