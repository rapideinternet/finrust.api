using AutoMapper;
using FinRust.Application.Common.Mappings;
using FinRust.Persistence;
using System;
using Xunit;

namespace FinRust.Application.UnitTests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FinRustDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixture()
        {
            Context = FinRustContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            FinRustContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}