using Newtonsoft.Json;

namespace Weather.Api.DTOs
{
    public class CurrentWeatherDto
    {
        [JsonIgnore]
        public string City { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
    }
}
