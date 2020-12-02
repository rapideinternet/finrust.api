using AutoMapper;
using FinRust.Application.Customers.Queries.GetCustomersList;
using FinRust.Application.UnitTests.Common;
using FinRust.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FinRustTraders.Application.UnitTests.Infrastructure
{
    [Collection("QueryCollection")]
    public class GetCustomersListQueryHandlerTests
    {
        private readonly FinRustDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetCustomersTest()
        {
            var sut = new GetCustomersListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetCustomersListQuery(), CancellationToken.None);

            result.ShouldBeOfType<CustomersListVm>();

            result.Customers.Count.ShouldBe(3);
        }
    }
}