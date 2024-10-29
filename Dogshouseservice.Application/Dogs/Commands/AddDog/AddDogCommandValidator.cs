using FluentValidation;

namespace Dogshouseservice.Application.Dogs.Commands.AddDog;

public class AddDogCommandValidator : AbstractValidator<AddDogCommand>
{
    public AddDogCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Color).NotEmpty();
        RuleFor(x => x.TailLength)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Tail length can't be negative.");
        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .WithMessage("Weight must be a positive number.");
    }
}