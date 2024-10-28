using ErrorOr;

namespace Dogshouseservice.Domain.Common.Errors;

public static class Errors
{
    public static class Dog
    {
        public static Error TailLenghtIsNegative => Error.Validation(code: "Dog.TailLenghtIsNegative", description:"Tail lenght can't be negative.");
    }
}