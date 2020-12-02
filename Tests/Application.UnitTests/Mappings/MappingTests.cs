using AutoMapper;
using FinRust.Application.Customers.Queries.GetCustomerDetail;
using FinRust.Application.Customers.Queries.Models;
using FinRust.Domain.Entities;
using Shouldly;
using Xunit;

namespace FinRust.Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerLookupDto()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerLookupDto>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerLookupDto>();
        }

        [Fact]
        public void ShouldMapCustomerToCustomerDetailVm()
        {
            var entity = new Customer();

            var result = _mapper.Map<CustomerDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<CustomerDetailVm>();
        }

    }
}
