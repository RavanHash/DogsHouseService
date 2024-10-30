using Dogshouseservice.Api.Controllers;
using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Dogshouseservice.Application.Dogs.Common;
using Dogshouseservice.Contracts.Dogs;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Dogshouseservice.Tests.Controllers;

public class DogsControllerTests
{
    private readonly DogsController _controller;
    private readonly Mock<ISender> _mediatorMock;

    public DogsControllerTests()
    {
        _mediatorMock = new Mock<ISender>();
        _controller = new DogsController(_mediatorMock.Object);
    }

    [Fact]
    public async Task AddDog_ShouldReturnCreated_WhenSuccessful()
    {
        // Arrange
        var request = new AddDogRequest("Buddy", "Brown", 10, 20);
        var dogResult = new DogsResult("Buddy", "Brown", 10, 20);

        _mediatorMock.Setup(m => m.Send(It.IsAny<AddDogCommand>(), default))
            .ReturnsAsync(dogResult);

        // Act
        var result = await _controller.AddDog(request);

        // Assert
        var actionResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal(201, actionResult.StatusCode);
        Assert.Equal($"/dogs/{dogResult.Name}", actionResult.Location);
    }

    [Fact]
    public async Task AddDog_ShouldReturnConflict_WhenNameAlreadyExists()
    {
        // Arrange
        var request = new AddDogRequest("Buddy", "Brown", 10, 20);

        _mediatorMock.Setup(m => m.Send(It.IsAny<AddDogCommand>(), default))
            .ReturnsAsync(Error.Conflict("Dog.NameAlreadyExists", "A dog with this name already exists."));

        // Act
        var result = await _controller.AddDog(request);

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(409, objectResult.StatusCode);
    }
}