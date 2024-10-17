using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            // Table name
            builder.ToTable("Receipts");

            // Primary key
            builder.HasKey(r => r.Id);

            // Properties
            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(r => r.Content)
                .IsRequired()
                .HasMaxLength(500); // Set max length for Content

            builder.Property(r => r.TransactionCode)
                .IsRequired()
                .HasMaxLength(100); // Set max length for TransactionCode

            builder.Property(r => r.BankAccountName)
                .HasMaxLength(100); // Optional BankAccountName with max length

            builder.Property(r => r.BankAccountNumber)
                .HasMaxLength(50); // Optional BankAccountNumber with max length

            builder.Property(r => r.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Set precision for Amount

            builder.Property(r => r.Currency)
                .IsRequired()
                .HasMaxLength(10); // Set max length for Currency (e.g., "USD", "VND")

            builder.Property(r => r.PaymentDate)
                .IsRequired();

            builder.Property(r => r.CreateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for CreateAt

            builder.Property(r => r.UpdateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for UpdateAt

            builder.Property(r => r.PaymentStatus)
                .IsRequired(); // Required field for PaymentStatus

            // Relationships
            builder.HasOne(r => r.PaymentAccount)
                .WithMany(pa => pa.ReceiptList)
                .HasForeignKey(r => r.PaymentAccountId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior

            builder.HasOne(r => r.User)
                .WithMany(u => u.Receipts)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
