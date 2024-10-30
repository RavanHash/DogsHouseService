using Dogshouseservice.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dogshouseservice.Api.Controllers;

public class PingController(IVersionService versionService) : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        var version = versionService.GetVersion();
        return Ok(version);
    }
}