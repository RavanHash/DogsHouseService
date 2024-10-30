using ErrorOr;

namespace Dogshouseservice.Domain.Common.Errors;

public static class Errors
{
    public static class Dog
    {
        public static Error NameAlreadyExists => Error.Conflict(
            "Dog.NameAlreadyExists",
            "A dog with this name already exists.");
    }
}