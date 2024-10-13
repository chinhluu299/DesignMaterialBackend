using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class PaymentAccountConfiguration : IEntityTypeConfiguration<PaymentAccount>
    {
        public void Configure(EntityTypeBuilder<PaymentAccount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(x => x.Type).WithMany(c => c.PaymentAccounts);
        }
    }
}
