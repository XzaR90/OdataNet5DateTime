using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Abstracts;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Routing.Conventions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;

namespace OdataNet5DateTime
{
    public static class ServiceCollectionOdataExtension
    {
        public static void AddConfiguratedOdata(this IServiceCollection services)
        {
            services.AddOData((opt,sp) =>
            {
                opt
                .SetTimeZoneInfo(TimeZoneInfo.Utc)
                .AddModel("odata", DefaultEdmModel.Create())
                .Select()
                .Filter()
                .OrderBy()
                .SkipToken()
                .Count()
                .SetMaxTop(100);
            });

            services.AddControllers(options =>
            {
                foreach (var outputFormatter in options.OutputFormatters.OfType<ODataOutputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
                foreach (var inputFormatter in options.InputFormatters.OfType<ODataInputFormatter>().Where(_ => _.SupportedMediaTypes.Count == 0))
                {
                    inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
                }
            });
        }
	}
}
