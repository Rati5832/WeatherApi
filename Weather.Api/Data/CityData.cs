namespace Weather.Api.Data
{
    public class CityData
    {
        private static readonly Dictionary<City, (double Latitude, double Longitude)> _coordinates = new()
        {
            { City.Tbilisi, (41.7151, 44.8271) },
            { City.Berlin, (52.5200, 13.4050) },
            { City.Paris, (48.8566, 2.3522) }
        };

        public static (double Latitude, double Longitude) GetCoordinates (City city) => _coordinates[city];

        public static (double Latitude, double Longitude)? GetCoordinates (String cityName )
        {
            if (Enum.TryParse<City>(cityName, true, out var city))
                return GetCoordinates(city);

            return null;
        }

        public static IEnumerable<string> GetAvailableCityNames() => _coordinates.Keys.Select(c => c.ToString());

    }
}
