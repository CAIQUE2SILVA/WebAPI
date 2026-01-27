using Microsoft.EntityFrameworkCore;
using WebAPI.Model.Context;

namespace WebAPI.Configurantions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("MSSQLServerSQLConnection");
            var connectionString = section["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                   throw new InvalidOperationException("Connection string 'MSSQLServerSQlConnectioString' not found.");
            }
            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
