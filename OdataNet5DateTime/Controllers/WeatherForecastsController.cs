using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace OdataNet5DateTime.Controllers
{
    [ODataRoutePrefix("[controller]")]
    public class WeatherForecastsController : ODataController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastsController> _logger;
        private readonly IMapper _mapper;

        public WeatherForecastsController(
            ILogger<WeatherForecastsController> logger, 
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [EnableQuery(MaxExpansionDepth = 1)]
        [ODataRoute]
        [HttpGet]
        public IQueryable<WeatherForecastDto> Get()
        {
            _logger.LogInformation("Testing datetime odata query");

            var rng = new Random();
            var query = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.UtcNow.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .AsQueryable();

            return _mapper.ProjectTo<WeatherForecastDto>(query);
        }
    }
}
