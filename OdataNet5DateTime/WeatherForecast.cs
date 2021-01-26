using System;

namespace OdataNet5DateTime
{
    public class WeatherForecastDto
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
    }
}
