using FinRust.Application.Common.Interfaces;
using FinRust.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Persistence
{
    public class SampleDataSeeder
    {
        private readonly IFinRustDbContext _context;
        private readonly IUserManager _userManager;

        private readonly Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();

        public SampleDataSeeder(IFinRustDbContext context, IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedCustomersAsync(cancellationToken);
            await SeedVisualizationsAsync(cancellationToken);
        }

        private async Task SeedVisualizationsAsync(CancellationToken cancellationToken)
        {
            var visualizations = new Visualization[]
            {
                new Visualization() {Name = "Visualization 1", CustomerId = Customers.First().Key},
                new Visualization() {Name = "Visualization 2", CustomerId = Customers.Last().Key}
            };

            _context.Visualizations.AddRange(visualizations);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task SeedCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = new[]
            {
                new Customer() {CustomerId = 1, Name = "John Doe"},
                new Customer() {CustomerId = 2, Name = "Alice River"},
                new Customer() {CustomerId = 3, Name = "Bob Sea"}
            };

            _context.Customers.AddRange(customers);

            foreach (var customer in customers)
            {
                this.Customers.Add(customer.CustomerId, customer);
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}