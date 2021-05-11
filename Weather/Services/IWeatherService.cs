using System;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecast(double latitude, double longitude);
    }
}
