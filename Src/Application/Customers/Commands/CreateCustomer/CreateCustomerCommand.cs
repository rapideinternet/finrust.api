using FinRust.Application.Common.Interfaces;
using FinRust.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateCustomerCommand>
        {
            private readonly IFinRustDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IFinRustDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = new Customer
                {
                    CustomerId = request.Id,
                    Name = request.Name,
                };

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
