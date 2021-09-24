using WeatherChecker.Domain.Models;

namespace WeatherChecker.Domain
{
    public interface IWeatherFetcher
    {
        CurrentWeather GetCurrentWeather(string key, string zipCode);
    }
}
