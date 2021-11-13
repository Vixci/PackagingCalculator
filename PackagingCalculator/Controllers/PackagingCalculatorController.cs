using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PackagingCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackagingCalculatorController : ControllerBase
    {
        private static readonly string[] product_types = new[]
        {
            "photoBook", "calendar", "canvas", "cards", "mug"
        };

        private readonly ILogger<PackagingCalculatorController> _logger;

        public PackagingCalculatorController(ILogger<PackagingCalculatorController> logger)
        {
            _logger = logger;
        }

        //[HttpPut]
        //public IEnumerable<WeatherForecast> Put(List<List<string>> orders,  )
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
