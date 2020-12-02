using MediatR;

namespace FinRust.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
