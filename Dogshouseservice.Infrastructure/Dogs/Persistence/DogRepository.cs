using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Domain.Dogs;

namespace Dogshouseservice.Infrastructure.Dogs.Persistence;

public class DogRepository : IDogsRepository
{
    private static readonly List<Dog> _dogsList = new();

    public void AddAsync(Dog dog)
    {
        _dogsList.Add(dog);
    }

    public List<Dog> GetAllAsync()
    {
        return _dogsList;
    }
}