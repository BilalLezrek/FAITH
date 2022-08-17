using Microsoft.AspNetCore.Mvc;
using Faith.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Faith.Server.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize] 
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Gebruiker> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Gebruiker
        {
        })
        .ToArray();
    }
}
