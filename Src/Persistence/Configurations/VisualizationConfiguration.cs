using FinRust.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinRust.Persistence.Configurations
{
    public class VisualizationConfiguration : IEntityTypeConfiguration<Visualization>
    {
        public void Configure(EntityTypeBuilder<Visualization> builder)
        {

            builder.Property(e => e.VisualizationId).HasColumnName("VisualizationID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasOne(d => d.Customer)
                .WithMany(p => p.Visualizations)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Customer_Visualizations");
        }
    }
}
