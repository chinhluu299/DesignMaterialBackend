using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class CurrencyUnitConfiguration : IEntityTypeConfiguration<CurrencyUnit>
    {
        public void Configure(EntityTypeBuilder<CurrencyUnit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Unit).HasMaxLength(50).IsRequired();
        }
    }
}
