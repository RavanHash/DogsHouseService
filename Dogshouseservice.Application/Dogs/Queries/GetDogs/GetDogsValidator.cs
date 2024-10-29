using FluentValidation;

namespace Dogshouseservice.Application.Dogs.Queries.GetDogs;

public class GetDogsValidator : AbstractValidator<GetDogsQuery>
{
    public GetDogsValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .When(x => x.PageNumber.HasValue)
            .WithMessage("Page number must be greater than zero.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .When(x => x.PageSize.HasValue)
            .WithMessage("Page size must be greater than zero.");

        RuleFor(x => x.Attribute!.ToLower())
            .Must(attr => new[] { "name", "color", "taillength", "weight" }.Contains(attr.ToLower()))
            .When(x => !string.IsNullOrEmpty(x.Attribute))
            .WithMessage("Invalid attribute for sorting.");

        RuleFor(x => x.Order!.ToLower())
            .Must(order => order.Equals("asc", StringComparison.OrdinalIgnoreCase) || order.Equals("desc", StringComparison.OrdinalIgnoreCase))
            .When(x => !string.IsNullOrEmpty(x.Order))
            .WithMessage("Order must be 'asc' or 'desc'.");
    } 
}