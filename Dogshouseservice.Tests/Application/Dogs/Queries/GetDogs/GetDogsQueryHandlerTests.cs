using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Application.Dogs.Queries.GetDogs;
using Dogshouseservice.Domain.Dogs;
using Moq;
using Xunit;

namespace Dogshouseservice.Tests.Application.Dogs.Queries.GetDogs;

public class GetDogsQueryHandlerTests
{
    private readonly Mock<IDogsRepository> _dogsRepositoryMock;
    private readonly GetDogsQueryHandler _handler;

    public GetDogsQueryHandlerTests()
    {
        _dogsRepositoryMock = new Mock<IDogsRepository>();
        _handler = new GetDogsQueryHandler(_dogsRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnListOfDogs()
    {
        // Arrange
        var query = new GetDogsQuery(null, null, null, null);
        var dogs = new List<Dog>
        {
            new() { Name = "Buddy", Color = "Brown", TailLength = 10, Weight = 20 },
            new() { Name = "Max", Color = "Black", TailLength = 15, Weight = 25 }
        };

        _dogsRepositoryMock.Setup(repo => repo.GetDogsAsync(null, null, null, null))
            .ReturnsAsync(dogs);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
    }
}