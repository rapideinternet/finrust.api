using AutoMapper;
using FinRust.Application.Customers.Queries.GetCustomerDetail;
using FinRust.Application.UnitTests.Common;
using FinRust.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinRust.Application.UnitTests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerDetailQueryHandlerTests
    {
        private readonly FinRustDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomerDetail()
        {
            var sut = new GetCustomerDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomerDetailQuery { Id = 1 }, CancellationToken.None);

            result.ShouldBeOfType<CustomerDetailVm>();
            result.Id.ShouldBe(1);
        }
    }
}
