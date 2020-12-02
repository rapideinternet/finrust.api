using FinRust.Application.Customers.Commands.CreateCustomer;
using FinRust.Application.Customers.Commands.DeleteCustomer;
using FinRust.Application.Customers.Commands.UpdateCustomer;
using FinRust.Application.Customers.Queries.GetCustomerDetail;
using FinRust.Application.Customers.Queries.GetCustomersList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinRust.WebUI.Controllers
{
    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CustomersListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetCustomersListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetCustomerDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return NoContent();
        }
    }
}