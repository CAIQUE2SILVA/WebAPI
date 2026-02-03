using Microsoft.Extensions.Options;

namespace WebAPI.Configurantions
{
    public static class CorsConfig
    {
        public static void AddCorsConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var oringis = configuration.GetSection("Cors:Origins")
                .Get<string[]>() ?? Array.Empty<string>();

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    policey =>
                    policey.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy",
                    policey =>
                    policey.WithOrigins(oringis)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });
        }
        public static IApplicationBuilder UseCorsConfiguration(this IApplicationBuilder app)
        {
            //app.UseCors();
            app.UseCors("DefaultPolicy");
            return app;
        }

    }

}
