using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Dogshouseservice.Application.Dogs.Queries.GetDogs;
using Dogshouseservice.Contracts.Dogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

public class DogsController(ISender mediator) : ApiController
{
    [HttpPost("/dog")]
    public async Task<IActionResult> AddDog([FromBody] AddDogRequest request)
    {
        var command = new AddDogCommand(
            request.Name,
            request.Color,
            request.TailLength,
            request.Weight);

        var result = await mediator.Send(command);

        return result.Match(
            res => Ok(res),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetDogs(
        [FromQuery] int? pageNumber,
        [FromQuery] int? pageSize,
        [FromQuery] string? attribute,
        [FromQuery] string? order)
    {
        var query = new GetDogsQuery(
            pageNumber,
            pageSize,
            attribute,
            order);

        var dogs = await mediator.Send(query);

        var response = dogs.Select(dog => new DogResponse(
            dog.Name,
            dog.Color,
            dog.TailLength,
            dog.Weight)).ToList();

        return Ok(response);
    }
}