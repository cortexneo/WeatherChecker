namespace WeatherChecker.Domain.Models
{
    public class CurrentWeather
    {
        public Current current { get; set; }
        public Location location { get; set; }

        public class Location
        {
            public string Country { get; set; }
        }
        public class Current
        {
            public string[] Weather_Descriptions { get; set; }
            public int UV_Index { get; set; }
            public int Wind_Speed { get; set; }
        }
    }
}
