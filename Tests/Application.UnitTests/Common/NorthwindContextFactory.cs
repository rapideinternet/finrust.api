using FinRust.Domain.Entities;
using FinRust.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace FinRust.Application.UnitTests.Common
{
    public class FinRustContextFactory
    {
        public static FinRustDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FinRustDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FinRustDbContext(options);

            context.Database.EnsureCreated();

            context.Customers.AddRange(new[] {
                new Customer { CustomerId = 1, Name = "Adam Cogan" },
                new Customer { CustomerId = 2, Name = "Jason Taylor" },
                new Customer { CustomerId = 3, Name = "Brendan Richards" },
            });

            context.Visualizations.Add(new Visualization()
            {
                CustomerId = 1,
                Name = "Visualization"
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(FinRustDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}