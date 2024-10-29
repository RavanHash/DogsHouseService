using System.Text.Json;
using Dogshouseservice.Application.Dogs.Commands.AddDog;
using Dogshouseservice.Application.Dogs.Queries.GetDogs;
using Dogshouseservice.Contracts.Dogs;
using Dogshouseservice.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

public class DogsController(ISender mediator) : ApiController
{
    [HttpPost]
    public async Task<IActionResult> AddDog([FromBody] AddDogRequest request)
    {
        try
        {
            var command = new AddDogCommand(
                request.Name,
                request.Color,
                request.TailLength,
                request.Weight);

            var result = await mediator.Send(command);
            
            if (result.IsError && result.FirstError == Errors.Dog.NameAlreadyExists)
            {
                return Conflict(new { message = result.FirstError.Description });
            }

            return result.Match(
                res => Ok(res),
                errors => Problem(errors));
        }
        catch (JsonException)
        {
            return BadRequest("Invalid JSON in request body.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An unexpected error occurred.");
        }
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