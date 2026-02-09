using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace WebAPI.Configurantions
{
    public static class ContentNegotiationConfig
    {
        public static IMvcBuilder AddContentNegotiation(this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(static options =>
            {
                options.RespectBrowserAcceptHeader = false;
                options.ReturnHttpNotAcceptable = false;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();
        }
    }
}
