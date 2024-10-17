using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DesignMaterialBackend.Data.Configurations
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            // Table name
            builder.ToTable("BlogCategories");

            // Primary key
            builder.HasKey(bc => bc.Id);

            // Properties
            builder.Property(bc => bc.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-increment for Id

            builder.Property(bc => bc.CategoryName)
                .IsRequired()
                .HasMaxLength(255); // Set max length for CategoryName

            builder.Property(bc => bc.Slug)
                .IsRequired()
                .HasMaxLength(255); // Slug should also have a max length

            // Relationships
            builder.HasMany(bc => bc.Blogs)
                .WithOne(b => b.BlogCategory)
                .HasForeignKey(b => b.CategoryID)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
