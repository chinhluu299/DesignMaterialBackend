using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            // Table name
            builder.ToTable("Blogs");

            // Primary key
            builder.HasKey(b => b.Id);

            // Properties
            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedOnAdd(); // Auto-increment for Id

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(255); // Set max length for Title

            builder.Property(b => b.Slug)
                .IsRequired()
                .HasMaxLength(255); // Slug should also have a max length

            builder.Property(b => b.Content)
                .IsRequired()
                .HasColumnType("text"); // Using text type for potentially large content

            builder.Property(b => b.Summary)
                .HasMaxLength(500); // Summary could have a smaller limit

            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100); // Author name limit

            builder.Property(b => b.PublishedDate)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(b => b.LastUpdatedDate)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(b => b.Status)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(b => b.ViewCount)
                .HasDefaultValue(0)
                .IsRequired(); // Now ViewCount is an integer

            builder.Property(b => b.ThumbnailUrl)
                .HasMaxLength(2048); // Assuming URL length limit

            builder.Property(b => b.CategoryID)
                .IsRequired(); // CategoryID is now an integer

            // Relationships
            builder.HasOne(b => b.BlogCategory)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryID)
                .OnDelete(DeleteBehavior.Restrict); // Define delete behavior
        }
    }
}
