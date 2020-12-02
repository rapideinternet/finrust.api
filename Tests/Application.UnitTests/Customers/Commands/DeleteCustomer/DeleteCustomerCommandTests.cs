using FinRust.Application.Common.Exceptions;
using FinRust.Application.Customers.Commands.DeleteCustomer;
using FinRust.Application.UnitTests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.Application.UnitTests.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTests : CommandTestBase
    {
        private readonly DeleteCustomerCommandHandler _sut;

        public DeleteCustomerCommandTests()
            : base()
        {
            _sut = new DeleteCustomerCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            var invalidId = 999;

            var command = new DeleteCustomerCommand { Id = invalidId };

            await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_GivenValidIdAndZeroOrders_DeletesCustomer()
        {
            var validId = 2;

            var command = new DeleteCustomerCommand { Id = validId };

            await _sut.Handle(command, CancellationToken.None);

            var customer = await _context.Customers.FindAsync(validId);

            Assert.Null(customer);
        }

        [Fact]
        public async Task Handle_GivenValidIdAndSomeOrders_ThrowsDeleteFailureException()
        {
            var validId = 1;

            var command = new DeleteCustomerCommand { Id = validId };

            await Assert.ThrowsAsync<DeleteFailureException>(() => _sut.Handle(command, CancellationToken.None));

        }
    }
}
