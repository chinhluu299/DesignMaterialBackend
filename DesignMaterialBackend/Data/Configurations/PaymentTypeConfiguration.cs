using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class PaymentTypeConfiguration : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            // Table name
            builder.ToTable("PaymentTypes");

            // Primary key
            builder.HasKey(pt => pt.Id);

            // Properties
            builder.Property(pt => pt.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100); // Set max length for Name

            builder.Property(pt => pt.Description)
                .HasMaxLength(255); // Optional Description field with max length

            builder.Property(pt => pt.IsOnline)
                .IsRequired()
                .HasDefaultValue(true); // Set default value to true

            builder.Property(pt => pt.CreateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for CreateAt

            builder.Property(pt => pt.UpdateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for UpdateAt

            // Relationships
            builder.HasMany(pt => pt.PaymentAccounts)
                .WithOne(pa => pa.PaymentType)
                .HasForeignKey(pa => pa.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
