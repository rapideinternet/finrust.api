using MediatR;

namespace FinRust.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
    {
        public int Id { get; set; }
    }
}
