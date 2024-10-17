using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            // Table name
            builder.ToTable("MaterialTypes");

            // Primary key
            builder.HasKey(mt => mt.Id);

            // Properties
            builder.Property(mt => mt.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-generate Guid

            builder.Property(mt => mt.Name)
                .IsRequired()
                .HasMaxLength(100); // Set max length for Name

            builder.Property(mt => mt.Other)
                .HasMaxLength(255); // Optional Other field with max length

            builder.Property(mt => mt.CreateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for CreateAt

            builder.Property(mt => mt.UpdateAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()"); // Default to current date for UpdateAt

            // Relationships
            builder.HasMany(mt => mt.Materials)
                .WithOne(m => m.MaterialTypes)
                .HasForeignKey(m => m.MaterialTypeId)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
