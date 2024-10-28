using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Contracts.Dogs;
using Dogshouseservice.Domain.Dogs;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DogsController : ControllerBase
{
    private readonly IDogsService _dogsService;

    public DogsController(IDogsService dogsService)
    {
        _dogsService = dogsService;
    }
    [HttpPost]
    public IActionResult AddDog(AddDogRequest request)
    {
        var res = _dogsService.AddDogAsync(request.Name,  request.Color, request.TailLength,  request.Weight);

        return res.MatchFirst(res => Ok(res), firstError => Problem(statusCode: StatusCodes.Status400BadRequest, title: firstError.Description));
    }

    [HttpGet]
    public IActionResult GetDogs()
    {
        var dogsResult = _dogsService.GetAllDogsAsync();

        List<DogResponse> response = new();
        foreach (var dog in dogsResult)
        {
            response.Add(new DogResponse(
                dog.Name,
                dog.Color,
                dog.TailLength,
                dog.Weight));
        }
        return Ok(response);
    }
}