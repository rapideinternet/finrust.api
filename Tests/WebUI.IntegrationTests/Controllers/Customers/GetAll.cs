using FinRust.Application.Customers.Queries.GetCustomersList;
using FinRust.WebUI.IntegrationTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.WebUI.IntegrationTests.Controllers.Customers
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/customers/getall");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<CustomersListVm>(response);

            Assert.IsType<CustomersListVm>(vm);
            Assert.NotEmpty(vm.Customers);
        }
    }
}
