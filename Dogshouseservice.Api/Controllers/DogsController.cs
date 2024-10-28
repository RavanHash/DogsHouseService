using Dogshouseservice.Application.Common.Interfaces;
using Dogshouseservice.Contracts.Dogs;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

public class DogsController : ApiController
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

        return res.Match(res => Ok(res), errors => Problem(errors));
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