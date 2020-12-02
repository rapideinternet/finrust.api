using FinRust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinRust.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(e => e.CustomerId)
                .HasColumnName("CustomerID")
                .HasMaxLength(5)
                .ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}
