using Microsoft.AspNetCore.Mvc;
using okta_aspnetcore_mvc_example.Models;
using okta_aspnetcore_mvc_example.Services.Weather;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace okta_aspnetcore_mvc_example.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _weatherService.GetWeatherAsync();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}