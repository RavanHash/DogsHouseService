using Dogshouseservice.Application.Dogs.Queries.GetDogs;
using FluentValidation.TestHelper;
using Xunit;

namespace Dogshouseservice.Tests.Application.Dogs.Queries.GetDogs;

public class GetDogsValidatorTests
{
    private readonly GetDogsValidator _validator = new();

    [Fact]
    public void Should_Not_Have_Error_When_Parameters_Are_Valid()
    {
        // Arrange
        var query = new GetDogsQuery(
            1,
            10,
            "name",
            "asc");

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("name")]
    [InlineData("Name")]
    [InlineData("color")]
    [InlineData("taillength")]
    [InlineData("weight")]
    public void Should_Not_Have_Error_When_Attribute_Is_Valid(string attribute)
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            null,
            attribute,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Attribute);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("height")]
    [InlineData("123")]
    public void Should_Have_Error_When_Attribute_Is_Invalid(string attribute)
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            null,
            attribute,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Attribute)
            .WithErrorMessage("Invalid attribute for sorting.");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("asc")]
    [InlineData("ASC")]
    [InlineData("desc")]
    [InlineData("DESC")]
    public void Should_Not_Have_Error_When_Order_Is_Valid(string order)
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            null,
            null,
            order);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Order);
    }

    [Theory]
    [InlineData("asc")]
    [InlineData("desc")]
    [InlineData("ASC")]
    [InlineData("DESC")]
    public void Should_Have_Error_When_Order_Is_Provided_Without_Attribute(string order)
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            null,
            null,
            order);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Attribute)
            .WithErrorMessage("Attribute must be provided when Order is specified.");
    }

    [Theory]
    [InlineData("asc", "name")]
    [InlineData("desc", "color")]
    public void Should_Not_Have_Error_When_Order_And_Attribute_Are_Provided(string order, string attribute)
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            null,
            attribute,
            order);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Attribute);
        result.ShouldNotHaveValidationErrorFor(x => x.Order);
    }

    [Fact]
    public void Should_Not_Have_Error_When_PageNumber_And_PageSize_Are_Valid()
    {
        // Arrange
        var query = new GetDogsQuery(
            1,
            10,
            null,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void Should_Have_Error_When_PageNumber_Is_Missing_But_PageSize_Is_Provided()
    {
        // Arrange
        var query = new GetDogsQuery(
            null,
            10,
            null,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageNumber)
            .WithErrorMessage("PageNumber must be provided when PageSize is specified.");
    }

    [Fact]
    public void Should_Have_Error_When_PageSize_Is_Missing_But_PageNumber_Is_Provided()
    {
        // Arrange
        var query = new GetDogsQuery(
            1,
            null,
            null,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageSize)
            .WithErrorMessage("PageSize must be provided when PageNumber is specified.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_Have_Error_When_PageNumber_Is_Invalid(int pageNumber)
    {
        // Arrange
        var query = new GetDogsQuery(
            pageNumber,
            10,
            null,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageNumber)
            .WithErrorMessage("Page number must be greater than zero.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Should_Have_Error_When_PageSize_Is_Invalid(int pageSize)
    {
        // Arrange
        var query = new GetDogsQuery(
            1,
            pageSize,
            null,
            null);

        // Act
        var result = _validator.TestValidate(query);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PageSize)
            .WithErrorMessage("Page size must be greater than zero.");
    }
}