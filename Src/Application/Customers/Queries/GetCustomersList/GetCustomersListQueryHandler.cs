using AutoMapper;
using AutoMapper.QueryableExtensions;
using FinRust.Application.Common.Interfaces;
using FinRust.Application.Customers.Queries.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListVm>
    {
        private readonly IFinRustDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IFinRustDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CustomersListVm
            {
                Customers = customers
            };

            return vm;
        }
    }
}
