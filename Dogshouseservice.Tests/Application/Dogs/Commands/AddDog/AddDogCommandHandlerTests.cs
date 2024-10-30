using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Dogshouseservice.Domain.Common.Errors;
using Dogshouseservice.Domain.Dogs;
using Moq;
using Xunit;

namespace Dogshouseservice.Tests.Application.Dogs.Commands.AddDog;

public class AddDogCommandHandlerTests
{
    private readonly Mock<IDogsRepository> _dogsRepositoryMock;
    private readonly AddDogCommandHandler _handler;

    public AddDogCommandHandlerTests()
    {
        _dogsRepositoryMock = new Mock<IDogsRepository>();
        _handler = new AddDogCommandHandler(_dogsRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnDogResult_WhenDogIsAddedSuccessfully()
    {
        // Arrange
        var command = new AddDogCommand("Buddy", "Brown", 10, 20);

        _dogsRepositoryMock.Setup(repo => repo.ExistsAsync("Buddy"))
            .ReturnsAsync(false);
        _dogsRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Dog>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsError);
        Assert.Equal("Buddy", result.Value.Name);
    }

    [Fact]
    public async Task Handle_ShouldReturnError_WhenDogNameAlreadyExists()
    {
        // Arrange
        var command = new AddDogCommand("Buddy", "Brown", 10, 20);

        _dogsRepositoryMock.Setup(repo => repo.ExistsAsync("Buddy"))
            .ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsError);
        Assert.Contains(Errors.Dog.NameAlreadyExists, result.Errors);
    }
}