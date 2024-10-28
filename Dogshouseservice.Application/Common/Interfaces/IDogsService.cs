using Dogshouseservice.Application.Services.Dogs;
using Dogshouseservice.Domain.Dogs;
using ErrorOr;

namespace Dogshouseservice.Application.Common.Interfaces;

public interface IDogsService
{
  ErrorOr<DogsResult> AddDogAsync(string name, string color, int tailLength, int weight);
  List<Dog> GetAllDogsAsync();
}