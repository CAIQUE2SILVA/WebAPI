using WebAPI.Hypermedia.Erricher;
using WebAPI.Hypermedia.Filters;

namespace WebAPI.Configurantions
{
    public static class HateOASConfig
    {
        public static IServiceCollection AddHATEOASConiguration
            (this IServiceCollection services)
        {
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(
                new PersonEnricher());
            services.AddSingleton(filterOptions);

            services.AddScoped<HyperMediaFilter>();
            return services;
        }

        public static void USeHATEOASRoutes(
            this IEndpointRouteBuilder app)
        {
            app.MapControllerRoute("Default", 
                "{controller=values}/v1/{id?}");
        }
    }


}
