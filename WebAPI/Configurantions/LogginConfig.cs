using Serilog;
namespace WebAPI.Configurantions
{
    public static class LogginConfig
    {
        public static void AddSerilogLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                //.WriteTo.Debug()
                .WriteTo.Console()
                .CreateLogger();
             //builder.Host.UseSerilog();
        }
    }
}
