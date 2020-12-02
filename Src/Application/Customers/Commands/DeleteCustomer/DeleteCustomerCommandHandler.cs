using FinRust.Application.Common.Exceptions;
using FinRust.Application.Common.Interfaces;
using FinRust.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IFinRustDbContext _context;

        public DeleteCustomerCommandHandler(IFinRustDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            var hasVisualizations = _context.Visualizations.Any(o => o.CustomerId == entity.CustomerId);
            if (hasVisualizations)
            {
                throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing visualizations associated with this customer.");
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
