using Microsoft.EntityFrameworkCore;
using WebAPI.Model.Context;

namespace WebAPI.Configurantions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabaseConfiguration(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("MSSQLServerSQLConnection")["ConnectionString"];

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string não encontrada em MSSQLServerSQLConnection:ConnectionString");

            services.AddDbContext<MSSQLContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
