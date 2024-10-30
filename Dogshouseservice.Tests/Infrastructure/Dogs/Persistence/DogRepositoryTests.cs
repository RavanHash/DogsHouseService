using Dogshouseservice.Domain.Dogs;
using Dogshouseservice.Infrastructure.Dogs.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Dogshouseservice.Tests.Infrastructure.Dogs.Persistence;

public class DogRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldAddDog()
    {
        // Arrange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        await using var context = new TestAppDbContext(options);
        await context.Database.EnsureCreatedAsync();

        var repository = new DogRepository(context);

        var dog = new Dog { Name = "Buddy", Color = "Brown", TailLength = 10, Weight = 20 };

        // Act
        await repository.AddAsync(dog);

        // Assert
        var addedDog = await context.Dogs.FindAsync("Buddy");
        Assert.NotNull(addedDog);
    }

    [Fact]
    public async Task ExistsAsync_ShouldReturnTrue_WhenDogExists()
    {
        // Arrange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connection)
            .Options;

        await using var context = new TestAppDbContext(options);
        await context.Database.EnsureCreatedAsync();

        var repository = new DogRepository(context);

        var dog = new Dog { Name = "Buddy2", Color = "Brown", TailLength = 10, Weight = 20 };
        await repository.AddAsync(dog);

        // Act
        var exists = await repository.ExistsAsync("Buddy2");

        // Assert
        Assert.True(exists);
    }
}