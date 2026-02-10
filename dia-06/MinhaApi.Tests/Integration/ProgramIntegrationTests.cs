using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MinhaApi.Tests.Integration
{
    public class ProgramIntegrationTests : IClassFixture<WebApplicationFactory<global::Program>>
    {
        private readonly WebApplicationFactory<global::Program> _factory;

        public ProgramIntegrationTests(WebApplicationFactory<global::Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task App_Starts_And_RespondsRoot()
        {
            var client = _factory.CreateClient();
            var resp = await client.GetAsync("/");

            Assert.NotNull(resp);
            Assert.InRange((int)resp.StatusCode, 100, 599);
        }
    }
}
