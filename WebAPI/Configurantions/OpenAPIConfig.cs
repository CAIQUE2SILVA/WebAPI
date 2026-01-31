using Microsoft.OpenApi;

namespace WebAPI.Configurantions
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "ASP.NET 2026 REST API's from 0 to Azure and GCP with .NET 8, Docker e Kubernetes";
        private static readonly string AppDescription = $"REST API RESFul";

        public static IServiceCollection AddOpenApiConfig(this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
            {
                Title = AppName,
                Version = "v1",
                Description = AppDescription,
                Contact = new OpenApiContact
                {
                    Name = "Caique",
                    Url = new Uri("https://caique-portifolio.netlify.app")
                },
                License = new OpenApiLicense 
                {
                    Name = "MIT"                }
            });
            return services;
        }
    }
}
