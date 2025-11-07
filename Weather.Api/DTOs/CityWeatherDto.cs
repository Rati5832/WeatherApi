using Newtonsoft.Json;

namespace Weather.Api.DTOs
{
    public class CityWeatherDto
    {
        [JsonProperty("current_weather")]
        public CurrentWeatherDto CurrentWeather { get; set; }
    }
}
