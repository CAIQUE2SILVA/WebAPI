using EvolveDb;
using Serilog;
using Microsoft.Data.SqlClient;

namespace WebAPI.Configurantions
{
    public static class EvolveConfig
    {
        public static IServiceCollection AddEvolveConfiguration(
       this IServiceCollection services,
       IConfiguration configuration,
       IWebHostEnvironment environment)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));
            if (environment is null) throw new ArgumentNullException(nameof(environment));

            var connectionString = configuration.GetSection("MSSQLServerSQLConnection")["ConnectionString"]
                ?? throw new InvalidOperationException("Connection string não encontrada em MSSQLServerSQLConnection:ConnectionString");

            if (!environment.IsDevelopment())
                return services;

            try
            {
                ExcuteMigrations(connectionString);

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Database migration failed.");
                throw;
            }

            return services;
        }

            public static void ExcuteMigrations(string connectionString)
            {
             try
             {
                using var evolveConnection = new SqlConnection(connectionString);
                var evolve = new Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();

            }
            catch (Exception ex) { }


            }
    }
}



