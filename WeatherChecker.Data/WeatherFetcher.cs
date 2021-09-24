using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherChecker.Domain;
using WeatherChecker.Domain.Models;

namespace WeatherChecker.Presentation
{
    public class WeatherFetcher : IWeatherFetcher
    {
        public CurrentWeather GetCurrentWeather(string key, string zipCode)
        {
            var json = RunAsync(key, zipCode).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<CurrentWeather>(json);
        }

        private HttpClient client = new HttpClient();

        private async Task<string> RunAsync(string key, string zipCode)
        {
            client.BaseAddress = new Uri("http://api.weatherstack.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = "";
            try
            {
                result = await GetWeatherAsync(key, zipCode);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        private async Task<string> GetWeatherAsync(string key, string zipCode)
        {
            var result = "";
            string url = $"/current?access_key={key}&query={zipCode}";

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine(response.ToString());
            }
            return result;
        }

    }
}
