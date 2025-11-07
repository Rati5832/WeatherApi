using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.Api.Service;

namespace Weather.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherByCity(string city)
        {
            var result = await _weatherService.GetWeatherFromCity(city);
            
            if(!result.Success)
            {
                if(result.Error.Contains("Invalid City", StringComparison.OrdinalIgnoreCase))
                {
                    return NotFound(new { message = result.Error });
                };

                return StatusCode(StatusCodes.Status502BadGateway, new { message = result.Error });
            }

            return Ok(result.Data);
        }
    }
}
