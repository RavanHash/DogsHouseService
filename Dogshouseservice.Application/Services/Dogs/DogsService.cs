using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Domain.Dogs;

namespace Dogshouseservice.Application.Services.Dogs;

public class DogsService : IDogsService
{
    private readonly IDogsRepository _dogsRepository;

    public DogsService(IDogsRepository dogsRepository)
    {
        _dogsRepository = dogsRepository;
    }

    public void AddDogAsync(string name, string color, int tailLength, int weight)
    {
        // check if exist

        var dog = new Dog
        {
            Name = name,
            Color = color,
            TailLength = tailLength,
            Weight = weight
        };

        _dogsRepository.AddAsync(dog);
    }

    public List<Dog> GetAllDogsAsync()
    {
        return _dogsRepository.GetAllAsync();
    }
}