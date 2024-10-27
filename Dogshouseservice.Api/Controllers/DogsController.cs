using Dogshouseservice.Application.Services.Dogs;
using Dogshouseservice.Contracts.Dogs;
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

    [HttpGet]
    public IActionResult GetDogs()
    {
        var dogsResult = _dogsService.GetAllDogs();

        var response = new DogResponse(
            dogsResult.Name,
            dogsResult.Color,
            dogsResult.TailLength,
            dogsResult.Weight);

        return Ok(response);
    }
}