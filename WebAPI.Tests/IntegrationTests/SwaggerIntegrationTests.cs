using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WebAPI.Tests.IntegrationTests.Tools;
using Xunit;

namespace WebAPI.Tests.IntegrationTests
{
    public class SwaggerIntegrationTests : IClassFixture<SqlServerFixture>
    {
        private readonly HttpClient _httpClient;
        public SwaggerIntegrationTests(SqlServerFixture sqlFixture)
        {
            var factory = new CustomWebApplicationFactory<Program>(sqlFixture.ConnecationString);
           
            _httpClient = factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    BaseAddress = new Uri("http://localhost")
                }
            );

        }

        [Fact]
        public async Task SwaggerJson_ShouldReturnSwaggerJson()
        {
            //Arrange & Act
            var response = await _httpClient
                .GetAsync("/swagger/v1/swagger.json");

            //Assert
            response.EnsureSuccessStatusCode();
            var contet = await response.Content.ReadAsStringAsync();
            contet.Should().NotBeNull();
            contet.Should().Contain("/api/person/v1");
        }

    }
}