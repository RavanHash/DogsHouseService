using ErrorOr;

namespace Dogshouseservice.Domain.Common.Errors;

public static class Errors
{
    public static class Dog
    {
        // Todo: move to validation
        public static Error TailLengthIsNegative => Error.Validation(code: "Dog.TailLengthIsNegative", description:"Tail length can't be negative.");
    }
}