using FinRust.Application.Customers.Queries.GetCustomerDetail;
using FinRust.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.WebUI.IntegrationTests.Controllers.Customers
{
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenId_ReturnsCustomerViewModel()
        {
            var client = _factory.GetAnonymousClient();

            var id = 1;

            var response = await client.GetAsync($"/api/customers/get/{id}");

            response.EnsureSuccessStatusCode();

            var customer = await Utilities.GetResponseContent<CustomerDetailVm>(response);

            Assert.Equal(id, customer.Id);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var invalidId = 999;

            var response = await client.GetAsync($"/api/customers/get/{invalidId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
