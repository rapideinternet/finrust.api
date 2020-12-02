using FinRust.Application.Common.Exceptions;
using FinRust.Application.Common.Interfaces;
using FinRust.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class Handler : IRequestHandler<UpdateCustomerCommand>
        {
            private readonly IFinRustDbContext _context;

            public Handler(IFinRustDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Customers
                    .SingleOrDefaultAsync(c => c.CustomerId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Customer), request.Id);
                }

                entity.Name = request.Name;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
