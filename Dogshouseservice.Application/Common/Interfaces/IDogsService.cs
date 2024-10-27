using Dogshouseservice.Application.Services.Dogs;
using Dogshouseservice.Domain.Dogs;

namespace Dogshouseservice.Application.Common.Interfaces;

public interface IDogsService
{
  void AddDogAsync(string name, string color, int tailLength, int weight);
  List<Dog> GetAllDogsAsync();
}