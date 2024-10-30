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

        RuleFor(x => x.PageNumber)
            .NotNull()
            .When(x => x.PageSize.HasValue)
            .WithMessage("PageNumber must be provided when PageSize is specified.");

        RuleFor(x => x.PageSize)
            .NotNull()
            .When(x => x.PageNumber.HasValue)
            .WithMessage("PageSize must be provided when PageNumber is specified.");

        RuleFor(x => x.Attribute)
            .Must(attr =>
            {
                if (string.IsNullOrEmpty(attr))
                    return true;

                var lowerAttr = attr.ToLower();
                return new[] { "name", "color", "taillength", "weight" }.Contains(lowerAttr);
            })
            .WithMessage("Invalid attribute for sorting.");

        RuleFor(x => x.Attribute)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .When(x => !string.IsNullOrEmpty(x.Order))
            .WithMessage("Attribute must be provided when Order is specified.")
            .Must(attr =>
            {
                if (string.IsNullOrEmpty(attr))
                    return true;

                var lowerAttr = attr.ToLower();
                return new[] { "name", "color", "taillength", "weight" }.Contains(lowerAttr);
            })
            .WithMessage("Invalid attribute for sorting.");

        RuleFor(x => x.Order)
            .Must((query, order) =>
            {
                if (string.IsNullOrEmpty(order))
                    return true;

                if (string.IsNullOrEmpty(query.Attribute))
                    return false;

                return order.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                       order.Equals("desc", StringComparison.OrdinalIgnoreCase);
            })
            .WithMessage("Order must be 'asc' or 'desc', and Attribute must be provided when Order is specified.");
    }
}