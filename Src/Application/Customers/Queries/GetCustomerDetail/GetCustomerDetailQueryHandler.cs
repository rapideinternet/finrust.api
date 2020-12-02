using AutoMapper;
using FinRust.Application.Common.Exceptions;
using FinRust.Application.Common.Interfaces;
using FinRust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailVm>
    {
        private readonly IFinRustDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandler(IFinRustDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDetailVm> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return _mapper.Map<CustomerDetailVm>(entity);
        }
    }
}
