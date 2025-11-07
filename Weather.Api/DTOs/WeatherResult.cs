namespace Weather.Api.DTOs
{
    public class WeatherResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public CurrentWeatherDto Data { get; set; }

    }
}
