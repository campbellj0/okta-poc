using okta_aspnetcore_mvc_example.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace okta_aspnetcore_mvc_example.Services.Weather
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
    }
}
