using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Dogshouseservice.Application.Dogs.Queries.GetDogs;
using Dogshouseservice.Contracts.Dogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

public class DogsController : ApiController
{
    private readonly ISender _mediator;

    public DogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddDog(AddDogRequest request)
    {
        var command = new AddDogCommand(request.Name, request.Color, request.TailLength, request.Weight);
        
        var res = await _mediator.Send(command);

        return res.Match(res => Ok(res), errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetDogs()
    {
        var query = new GetDogsQuery();
        
        var dogsResult = await _mediator.Send(query);

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