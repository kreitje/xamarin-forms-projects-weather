using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Models;

namespace Weather.Services
{
    public class OpenWeatherMapWeatherService : IWeatherService
    {
        public OpenWeatherMapWeatherService()
        {
        }

        public async Task<Forecast> GetForecast(double latitude, double longitude)
        {
            var language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var apiKey = "your api key";
            var uri = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&units=metric&lang={language}&appid={apiKey}";

            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(uri);

            var data = JsonConvert.DeserializeObject<WeatherData>(result);

            var forecast = new Forecast()
            {
                City = data.city.name,
                Items = data.list.Select(x => new ForecastItem()
                {
                    DateTime = ToDateTime(x.dt),
                    Temperature = x.main.temp,
                    WindSpeed = x.wind.speed,
                    Description = x.weather.First().description,
                    Icon = $"http://openweathermap.org/img/w/{x.weather.First().icon}.png"
                }).ToList()
            };

            return forecast;
        }

        private DateTime ToDateTime(double unixTimestamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimestamp).ToLocalTime();
            return dateTime;
        }
    }
}
