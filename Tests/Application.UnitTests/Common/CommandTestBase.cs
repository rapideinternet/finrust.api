using FinRust.Persistence;
using System;

namespace FinRust.Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly FinRustDbContext _context;

        public CommandTestBase()
        {
            _context = FinRustContextFactory.Create();
        }

        public void Dispose()
        {
            FinRustContextFactory.Destroy(_context);
        }
    }
}