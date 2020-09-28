using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using okta_aspnetcore_mvc_example.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace okta_aspnetcore_mvc_example.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        // How to pass/verify Open ID token between .net core web app and web api?
        // https://stackoverflow.com/questions/59687103/how-to-pass-verify-open-id-token-between-net-core-web-app-and-web-api

        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _context;
        private readonly IWeatherProvider _provider;

        public WeatherService(HttpClient client, IHttpContextAccessor context, IWeatherProvider provider)
        {
            _client = client;
            _context = context;
            _provider = provider;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
        {
            List<WeatherForecast> model;
            try
            {

                //var token = await _context.HttpContext?.GetTokenAsync("id_token");
                //var client = new HttpClient();
                //client.BaseAddress = new Uri(_provider.BaseAddress);
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //var response = await client.GetAsync("WeatherForecast");
                //var json = await response.Content.ReadAsStringAsync();

                var token = await _context.HttpContext?.GetTokenAsync("id_token");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var uri = "WeatherForecast";
                var response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<WeatherForecast>>(json);
                return model;
            }
            catch (Exception ex)
            {
                var e = ex.ToString();
            }
            return null;
        }
    }
}
