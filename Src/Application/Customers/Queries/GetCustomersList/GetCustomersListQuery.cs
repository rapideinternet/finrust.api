using MediatR;

namespace FinRust.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListVm>
    {
    }
}
