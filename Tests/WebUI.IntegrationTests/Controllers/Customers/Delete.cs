using FinRust.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.WebUI.IntegrationTests.Controllers.Customers
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenId_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var validId = 2;

            var response = await client.DeleteAsync($"/api/customers/delete/{validId}");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var invalidId = 999;

            var response = await client.DeleteAsync($"/api/customers/delete/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
