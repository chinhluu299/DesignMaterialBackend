using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class PaymentAccountConfiguration : IEntityTypeConfiguration<PaymentAccount>
    {
        public void Configure(EntityTypeBuilder<PaymentAccount> builder)
        {
            // Table name
            builder.ToTable("PaymentAccounts");

            // Primary key
            builder.HasKey(pa => pa.Id);

            // Properties
            builder.Property(pa => pa.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(pa => pa.Name)
                .IsRequired()
                .HasMaxLength(100); // Set max length for Name

            builder.Property(pa => pa.AccountNumber)
                .HasMaxLength(50); // Optional AccountNumber field with max length

            builder.Property(pa => pa.BankName)
                .HasMaxLength(100); // Optional BankName field with max length

            builder.Property(pa => pa.MomoNumber)
                .HasMaxLength(20); // Optional MomoNumber field with max length (assuming phone numbers)

            builder.Property(pa => pa.ZaloNumber)
                .HasMaxLength(20); // Optional ZaloNumber field with max length (assuming phone numbers)

            builder.Property(pa => pa.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for UpdatedAt

            // Relationships
            builder.HasOne(pa => pa.PaymentType)
                .WithMany(pt => pt.PaymentAccounts)
                .HasForeignKey(pa => pa.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior

            builder.HasMany(pa => pa.ReceiptList)
                .WithOne(r => r.PaymentAccount)
                .HasForeignKey(r => r.PaymentAccountId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior for Receipts
        }
    }
}
