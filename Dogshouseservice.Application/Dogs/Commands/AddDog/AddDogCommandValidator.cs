using FluentValidation;

namespace Dogshouseservice.Application.Dogs.Commands.AddDog;

public class AddDogCommandValidator : AbstractValidator<AddDogCommand>
{
    public AddDogCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.TailLength).NotEmpty();
        RuleFor(x => x.Weight).NotEmpty();
    }
}