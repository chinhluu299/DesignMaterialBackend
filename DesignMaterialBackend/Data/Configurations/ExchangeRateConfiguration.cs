﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignMaterialBackend.Data.Configurations
{
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.Property(e => e.Rate)
               .IsRequired() 
               .HasColumnType("float");

          
            builder.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()"); 

            builder.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .IsRequired(false); 

            builder.Property(e => e.Active)
                .HasDefaultValue(false); 

            builder.HasOne(e => e.CurrencyUnit)
                .WithMany(c => c.ExchangeRates) 
                .HasForeignKey("CurrenyUnit");
        }
    }
}