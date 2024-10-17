using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class CurrencyUnitConfiguration : IEntityTypeConfiguration<CurrencyUnit>
    {
        public void Configure(EntityTypeBuilder<CurrencyUnit> builder)
        {
            // Table name
            builder.ToTable("CurrencyUnits");

            // Primary key
            builder.HasKey(cu => cu.Id);

            // Properties
            builder.Property(cu => cu.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(cu => cu.Unit)
                .IsRequired()
                .HasMaxLength(50); // Set max length for Unit

            builder.Property(cu => cu.Description)
                .HasMaxLength(500); // Set max length for Description (optional)

            builder.Property(cu => cu.CreateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default value is the current date/time in SQL

            // Relationships
            builder.HasMany(cu => cu.ExchangeRates)
                .WithOne(er => er.CurrencyUnit)
                .HasForeignKey(er => er.CurrencyUnitId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}

