using Dogshouseservice.Application.Common;
using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Application.Dogs.Common;
using Dogshouseservice.Domain.Common.Errors;
using Dogshouseservice.Domain.Dogs;
using ErrorOr;
using MediatR;

namespace Dogshouseservice.Application.Dogs.Commands.AddDog;

public class AddDogCommandHandler(IDogsRepository dogsRepository) : IRequestHandler<AddDogCommand, ErrorOr<DogsResult>>
{
    public async Task<ErrorOr<DogsResult>> Handle(
        AddDogCommand command,
        CancellationToken cancellationToken)
    {
        if (await dogsRepository.ExistsAsync(command.Name))
        {
            return Errors.Dog.NameAlreadyExists;
        }

        var dog = new Dog
        {
            Name = command.Name,
            Color = command.Color,
            TailLength = command.TailLength,
            Weight = command.Weight
        };

        await dogsRepository.AddAsync(dog);

        var dogRes = new DogsResult(
            dog.Name,
            dog.Color,
            dog.TailLength,
            dog.Weight);

        return dogRes;
    }
}