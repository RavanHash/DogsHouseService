using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Domain.Common.Errors;
using Dogshouseservice.Domain.Dogs;
using ErrorOr;

namespace Dogshouseservice.Application.Services.Dogs;

public class DogsService : IDogsService
{
    private readonly IDogsRepository _dogsRepository;

    public DogsService(IDogsRepository dogsRepository)
    {
        _dogsRepository = dogsRepository;
    }

    public ErrorOr<DogsResult> AddDogAsync(string name, string color, int tailLength, int weight)
    {
        // check if exist

        if (tailLength < 0)
        {
            return Errors.Dog.TailLenghtIsNegative;
        }

        var dog = new Dog
        {
            Name = name,
            Color = color,
            TailLength = tailLength,
            Weight = weight
        };

        _dogsRepository.AddAsync(dog);

        var dogRes = new DogsResult ( dog.Name, dog.Color, dog.TailLength, dog.Weight );

        return dogRes;
    }

    public List<Dog> GetAllDogsAsync()
    {
        return _dogsRepository.GetAllAsync();
    }
}