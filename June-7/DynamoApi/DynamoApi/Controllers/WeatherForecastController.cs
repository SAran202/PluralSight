using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IDynamoDBContext _dynamoDbContext;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            IDynamoDBContext dynamoDbContext,
            ILogger<WeatherForecastController> logger)
        {
            _dynamoDbContext = dynamoDbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(string city = "Brisbane")
        {
            return await _dynamoDbContext
                            .QueryAsync<WeatherForecast>(city, Amazon.DynamoDBv2.DocumentModel.QueryOperator.Between, new object[] { DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddDays(2) })
                            .GetRemainingAsync();
        }

        [HttpPost]
        public async Task Post(string city)
        {
            var data = GenerateDummyDataWeatherForecast(city);
            foreach (var item in data)
            {
                await _dynamoDbContext.SaveAsync(item);
            }
        }

        [HttpDelete]
        public async Task Delete(string city)
        {
            var specification = await _dynamoDbContext.LoadAsync<WeatherForecast>(city, DateTime.Now.Date.AddDays(1));
            await _dynamoDbContext.DeleteAsync(specification);
        }

        private static IEnumerable<WeatherForecast> GenerateDummyDataWeatherForecast(string city)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                City=city,
                Date = DateTime.Now.Date.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
