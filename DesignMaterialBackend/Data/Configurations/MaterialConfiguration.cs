using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            // Table name
            builder.ToTable("Materials");

            // Primary key
            builder.HasKey(m => m.Id);

            // Properties
            builder.Property(m => m.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(255); // Set max length for Title

            builder.Property(m => m.Description)
                .HasMaxLength(500); // Optional description with max length

            builder.Property(m => m.Content)
                .IsRequired()
                .HasColumnType("text"); // Assuming large text data for content

            builder.Property(m => m.Url)
                .IsRequired()
                .HasMaxLength(2048); // Set max length for URL

            builder.Property(m => m.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); // Set Price with precision for currency

            builder.Property(m => m.CountDownloaded)
                .IsRequired()
                .HasDefaultValue(0); // Set default value to 0 for CountDownloaded

            builder.Property(m => m.CreateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for CreateAt

            builder.Property(m => m.UpdateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for UpdateAt

            // Relationships
            builder.HasOne(m => m.MaterialTypes)
                .WithMany(mt => mt.Materials)
                .HasForeignKey(m => m.MaterialTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
