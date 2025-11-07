using Weather.Api.DTOs;

namespace Weather.Api.Service
{
    public interface IWeatherService
    {
        Task<WeatherResult> GetWeatherFromCity(string city);
    }
}
