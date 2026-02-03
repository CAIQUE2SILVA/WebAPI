using Testcontainers.MsSql;
using WebAPI.Configurantions;
using Xunit;

namespace WebAPI.Tests.IntegrationTests.Tools
{
    public class SqlServerFixture : IAsyncLifetime
    {
        public MsSqlContainer Container { get; }

        public string ConnecationString  => Container.GetConnectionString();
        
        public SqlServerFixture()
        {
            Container = new MsSqlBuilder()
                .WithPassword("@Admin123")
                .Build();
        }

        public async Task InitializeAsync()
        {
            await Container.StartAsync();
            EvolveConfig.ExcuteMigrations(ConnectionString);
        }

        public async Task DisposeAsync()
        {
            await Container.DisposeAsync();
        }


    }
}
