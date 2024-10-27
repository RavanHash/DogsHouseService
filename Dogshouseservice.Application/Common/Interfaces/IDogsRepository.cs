using Dogshouseservice.Domain.Dogs;

namespace Dogshouseservice.Application.Common.Interfaces;

public interface  IDogsRepository
{
    void AddAsync(Dog dog);
    List<Dog> GetAllAsync();
}