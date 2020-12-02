using Microsoft.EntityFrameworkCore;

namespace FinRust.Persistence
{
    public class FinRustDbContextFactory : DesignTimeDbContextFactoryBase<FinRustDbContext>
    {
        protected override FinRustDbContext CreateNewInstance(DbContextOptions<FinRustDbContext> options)
        {
            return new FinRustDbContext(options);
        }
    }
}
