using Dogshouseservice.Domain.Dogs;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.Infrastructure.Dogs.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Dog> Dogs { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dog>()
            .HasKey(d => d.Name);

        modelBuilder.Entity<Dog>().HasData(
            new Dog { Name = "Neo", Color = "red & amber", TailLength = 22, Weight = 32 },
            new Dog { Name = "Jessy", Color = "black & white", TailLength = 7, Weight = 14 },
            new Dog { Name = "Buddy", Color = "brown", TailLength = 10, Weight = 20 },
            new Dog { Name = "Max", Color = "black", TailLength = 8, Weight = 18 },
            new Dog { Name = "Charlie", Color = "golden", TailLength = 15, Weight = 25 },
            new Dog { Name = "Rocky", Color = "gray", TailLength = 12, Weight = 24 },
            new Dog { Name = "Bella", Color = "white", TailLength = 9, Weight = 17 },
            new Dog { Name = "Lucy", Color = "cream", TailLength = 13, Weight = 23 },
            new Dog { Name = "Daisy", Color = "black & tan", TailLength = 16, Weight = 26 },
            new Dog { Name = "Molly", Color = "chocolate", TailLength = 11, Weight = 19 },
            new Dog { Name = "Bailey", Color = "blue & white", TailLength = 14, Weight = 22 },
            new Dog { Name = "Maggie", Color = "brindle", TailLength = 18, Weight = 27 },
            new Dog { Name = "Sophie", Color = "red", TailLength = 10, Weight = 20 },
            new Dog { Name = "Sadie", Color = "black", TailLength = 7, Weight = 15 },
            new Dog { Name = "Lola", Color = "golden", TailLength = 20, Weight = 30 },
            new Dog { Name = "Zoe", Color = "tan", TailLength = 12, Weight = 22 },
            new Dog { Name = "Cooper", Color = "gray", TailLength = 15, Weight = 28 },
            new Dog { Name = "Buster", Color = "white", TailLength = 9, Weight = 16 },
            new Dog { Name = "Oscar", Color = "cream", TailLength = 14, Weight = 24 },
            new Dog { Name = "Teddy", Color = "black & white", TailLength = 17, Weight = 29 },
            new Dog { Name = "Bentley", Color = "brown", TailLength = 8, Weight = 18 },
            new Dog { Name = "Roxy", Color = "blue", TailLength = 11, Weight = 21 },
            new Dog { Name = "Harley", Color = "black & tan", TailLength = 12, Weight = 22 },
            new Dog { Name = "Chloe", Color = "brindle", TailLength = 19, Weight = 31 },
            new Dog { Name = "Luna", Color = "red & white", TailLength = 21, Weight = 32 },
            new Dog { Name = "Leo", Color = "black", TailLength = 9, Weight = 17 },
            new Dog { Name = "Jack", Color = "golden", TailLength = 13, Weight = 23 },
            new Dog { Name = "Finn", Color = "gray", TailLength = 10, Weight = 20 },
            new Dog { Name = "Zeus", Color = "white & tan", TailLength = 16, Weight = 25 },
            new Dog { Name = "Hank", Color = "chocolate", TailLength = 11, Weight = 21 },
            new Dog { Name = "Gus", Color = "blue & white", TailLength = 18, Weight = 27 },
            new Dog { Name = "Riley", Color = "black & red", TailLength = 14, Weight = 22 },
            new Dog { Name = "Scout", Color = "tan & white", TailLength = 12, Weight = 19 },
            new Dog { Name = "Oliver", Color = "black", TailLength = 20, Weight = 30 },
            new Dog { Name = "Dexter", Color = "golden", TailLength = 15, Weight = 24 },
            new Dog { Name = "Sam", Color = "gray", TailLength = 7, Weight = 14 },
            new Dog { Name = "Rusty", Color = "brindle", TailLength = 10, Weight = 20 },
            new Dog { Name = "Tank", Color = "red", TailLength = 13, Weight = 23 },
            new Dog { Name = "Jasper", Color = "black & white", TailLength = 17, Weight = 28 },
            new Dog { Name = "Boomer", Color = "white", TailLength = 8, Weight = 16 },
            new Dog { Name = "Chase", Color = "cream", TailLength = 11, Weight = 21 },
            new Dog { Name = "Bandit", Color = "tan", TailLength = 9, Weight = 18 },
            new Dog { Name = "Ace", Color = "blue", TailLength = 16, Weight = 26 },
            new Dog { Name = "Simba", Color = "black & tan", TailLength = 19, Weight = 29 },
            new Dog { Name = "Bruce", Color = "chocolate", TailLength = 22, Weight = 33 },
            new Dog { Name = "Thor", Color = "gray", TailLength = 14, Weight = 24 },
            new Dog { Name = "Bruno", Color = "black", TailLength = 7, Weight = 15 },
            new Dog { Name = "Koda", Color = "golden", TailLength = 18, Weight = 28 },
            new Dog { Name = "Marley", Color = "white & red", TailLength = 10, Weight = 19 }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}