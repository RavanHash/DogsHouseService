using Dogshouseservice.Domain.Dogs;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.Infrastructure.Dogs.Persistence;

public class TestAppDbContext(DbContextOptions<AppDbContext> options) : AppDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dog>()
            .HasKey(d => d.Name);
    }
}