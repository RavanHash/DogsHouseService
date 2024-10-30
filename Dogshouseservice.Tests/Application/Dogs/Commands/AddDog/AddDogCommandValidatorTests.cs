using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Xunit;

namespace Dogshouseservice.Tests.Application.Dogs.Commands.AddDog;

public class AddDogCommandValidatorTests
{
    private readonly AddDogCommandValidator _validator;

    public AddDogCommandValidatorTests()
    {
        _validator = new AddDogCommandValidator();
    }

    [Fact]
    public void Validate_ShouldBeValid_WhenAllPropertiesAreValid()
    {
        // Arrange
        var command = new AddDogCommand("Buddy", "Brown", 10, 20);

        // Act
        var result = _validator.Validate(command);

        // Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validate_ShouldBeInvalid_WhenTailLengthIsNegative()
    {
        // Arrange
        var command = new AddDogCommand("Buddy", "Brown", -5, 20);

        // Act
        var result = _validator.Validate(command);

        // Assert
        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == "TailLength");
    }
}