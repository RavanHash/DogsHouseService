namespace Dogshouseservice.Application.Services.Dogs;

public class DogsService : IDogsService
{
    public DogsResult GetAllDogs()
    {
        return new DogsResult(
            "Test",
            "test",
            1,
            1);
    }
}