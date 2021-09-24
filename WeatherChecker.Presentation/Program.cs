using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using WeatherChecker.Domain;
using WeatherChecker.Presentation;

namespace WeatherChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Display();

            while (true)
            {
                var selected = Console.ReadKey();

                switch (selected.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        ExecuteWeatherChecker();
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Display();
                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.WriteLine();
                        return;
                }
            }
        }


        static void ExecuteWeatherChecker()
        {

            Console.WriteLine();
            Console.WriteLine("Please input your zipcode:");
            var zipcode = Console.ReadLine();

            IWeatherFetcher wf = new WeatherFetcher();
            var currentWeather = wf.GetCurrentWeather(GetApiKey(), zipcode);

            Console.WriteLine("===========================================");

            if (currentWeather.current != null)
            {

                Console.WriteLine($"Country: {currentWeather.location.Country}");

                Console.WriteLine($"Should I go outside? {(currentWeather.current.Weather_Descriptions.Any(s => s.Contains("Rain")) ? "No" : "Yes")}");

                Console.WriteLine($"Should I wear sunscreen? {(currentWeather.current.UV_Index > 3 ? "Yes" : "No")}");

                Console.WriteLine($"Can I fly my kite? {(!currentWeather.current.Weather_Descriptions.Any(s => s.Contains("Rain")) && currentWeather.current.Wind_Speed > 15 ? "Yes" : "No")}");
            }
            else
            {
                Console.WriteLine("Unrecognized Zipcode!");
            }

            Console.WriteLine("===========================================");
        }

        static void Display()
        {
            Console.WriteLine("What you like to do?");
            Console.WriteLine();
            Console.WriteLine("1 - Execute Weather Checker");
            Console.WriteLine("2 - Clear Screen");
            Console.WriteLine("3 - Exit");
        }

        private static string GetApiKey()
        {
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<Startup>();

            IConfigurationRoot configuration = builder.Build();
            return configuration["APIAccessKey:key"];
        }
    }
}
