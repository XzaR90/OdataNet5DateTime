using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdataNet5DateTime
{
    internal static class DefaultEdmModel
    {
        internal static IEdmModel Create()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<WeatherForecastDto>("WeatherForecasts");
            odataBuilder.EnableLowerCamelCase();
            return odataBuilder.GetEdmModel();
        }
    }

}
