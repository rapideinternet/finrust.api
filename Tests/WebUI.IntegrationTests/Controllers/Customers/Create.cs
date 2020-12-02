using FinRust.Application.Customers.Commands.CreateCustomer;
using FinRust.WebUI.IntegrationTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.WebUI.IntegrationTests.Controllers.Customers
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenCreateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var command = new CreateCustomerCommand
            {
                Id = 12,
                Name = "John Does"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/customers/create", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
