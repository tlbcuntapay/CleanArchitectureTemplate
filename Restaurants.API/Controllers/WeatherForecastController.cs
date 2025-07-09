using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class WeatherForecastRequest
{
    public int minTemp { get; set; }
    public int maxTemp { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastServices _weatherForecastServices;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastServices weatherForecastServices)
    {
        _logger = logger;
        _weatherForecastServices = weatherForecastServices;
    }

    [HttpPost("generate")]
    public IActionResult Generate([FromQuery] int take, [FromBody] WeatherForecastRequest request)
    {
        if (take < 0 || request.maxTemp < request.minTemp)
            return BadRequest();

        var results = _weatherForecastServices.Get(take, request.minTemp, request.maxTemp);
        return Ok(results);
    }
}
