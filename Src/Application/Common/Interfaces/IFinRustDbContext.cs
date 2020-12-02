using FinRust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FinRust.Application.Common.Interfaces
{
    public interface IFinRustDbContext
    {
        DbSet<Visualization> Visualizations { get; set; }

        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
