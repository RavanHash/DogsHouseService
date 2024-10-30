using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Domain.Dogs;
using Microsoft.EntityFrameworkCore;

namespace Dogshouseservice.Infrastructure.Dogs.Persistence;

public class DogRepository(AppDbContext context) : IDogsRepository
{
    public async Task AddAsync(Dog dog)
    {
        context.Dogs.Add(dog);
        await context.SaveChangesAsync();
    }

    public async Task<List<Dog>> GetAllAsync()
    {
        return await context.Dogs.ToListAsync();
    }

    public async Task<bool> ExistsAsync(string name)
    {
        return await context.Dogs.AnyAsync(d => d.Name == name);
    }

    public async Task<List<Dog>> GetDogsAsync(
        int? pageNumber,
        int? pageSize,
        string? attribute,
        string? order)
    {
        var query = context.Dogs.AsQueryable();

        if (!string.IsNullOrEmpty(attribute))
        {
            var sortOrder = (order ?? "asc").ToLower();
            query = attribute.ToLower() switch
            {
                "name" => sortOrder == "desc"
                    ? query.OrderByDescending(d => d.Name)
                    : query.OrderBy(d => d.Name),
                "color" => sortOrder == "desc"
                    ? query.OrderByDescending(d => d.Color)
                    : query.OrderBy(d => d.Color),
                "taillength" => sortOrder == "desc"
                    ? query.OrderByDescending(d => d.TailLength)
                    : query.OrderBy(d => d.TailLength),
                "weight" => sortOrder == "desc"
                    ? query.OrderByDescending(d => d.Weight)
                    : query.OrderBy(d => d.Weight),
                _ => query
            };
        }

        if (!pageNumber.HasValue || !pageSize.HasValue) return await query.ToListAsync();
        var skip = (pageNumber.Value - 1) * pageSize.Value;
        query = query.Skip(skip).Take(pageSize.Value);

        return await query.ToListAsync();
    }
}