using FinRust.Application.Customers.Commands.UpdateCustomer;
using FinRust.WebUI.IntegrationTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.WebUI.IntegrationTests.Controllers.Customers
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenUpdateCustomerCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var command = new UpdateCustomerCommand
            {
                Id = 2,
                Name = "New Name"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PutAsync($"/api/customers/update/{command.Id}", content);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenUpdateCustomerCommandWithInvalidId_ReturnsNotFoundStatusCode()
        {
            var client = _factory.GetAnonymousClient();

            var invalidCommand = new UpdateCustomerCommand
            {
                Id = 999,
                Name = "New Name",
            };

            var content = Utilities.GetRequestContent(invalidCommand);

            var response = await client.PutAsync($"/api/customers/update/{invalidCommand.Id}", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
