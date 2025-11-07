using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Weather.Api.Data;
using Weather.Api.DTOs;

namespace Weather.Api.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherService> _logger;


        public WeatherService(HttpClient httpClient, ILogger<WeatherService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

        }

        public async Task<WeatherResult> GetWeatherFromCity(string city)
        {

            var coords = CityData.GetCoordinates(city);
            if (coords == null)
            {
                var availableCities = string.Join(", ", CityData.GetAvailableCityNames());

                return new WeatherResult
                {
                    Success = false,
                    Error = $"Invalid city name: {city}. Available city weathers are for: {availableCities}"
                };
            }

            var (lat, lon) = coords.Value;
            _logger.LogInformation("Getting weather for {City} (Lat: {Lat}, Lon: {Lon})", city, lat, lon);

            var response = await _httpClient.GetAsync($"forecast?latitude={lat}&longitude={lon}&current_weather=true");
            if (!response.IsSuccessStatusCode)
            {
                return new WeatherResult
                {
                    Success = false,
                    Error = $"Call failed with status {response.StatusCode}"
                };
            }

            var stringResponse = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<CityWeatherDto>(stringResponse);

            var weatherInfo = new CurrentWeatherDto()
            {
                City = city,
                Temperature = dto.CurrentWeather.Temperature,
                WindSpeed = dto.CurrentWeather.WindSpeed
            };

            return new WeatherResult { Success = true, Data = weatherInfo };
        }
    }
}
