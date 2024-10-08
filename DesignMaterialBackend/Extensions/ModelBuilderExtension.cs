using DesignMaterialBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignMaterialBackend.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Initialize Currency Unit
            CurrencyUnit vndUnit = new CurrencyUnit()
            {
                Id = Guid.NewGuid(),
                Unit = "VND",
                Description = "Vietnamese Dong",
                CreateAt = DateTime.Now,
            };
            modelBuilder.Entity<CurrencyUnit>().HasData(vndUnit);

            //Exchange Rate
            ExchangeRate vndRate = new ExchangeRate()
            {
                CurrencyUnit = vndUnit,
                Active = true,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Rate = 1000,
            };
            modelBuilder.Entity<ExchangeRate>().HasData(vndRate);

            //Initialize Payment Type
            PaymentType momo = new PaymentType()
            {
                Id = Guid.NewGuid(),
                Name = "Momo",
                Description = "",
                IsOnline = true
            };
            PaymentType bank = new PaymentType()
            {
                Id = Guid.NewGuid(),
                Name = "Banking",
                Description = "",
                IsOnline = true
            };
            modelBuilder.Entity<PaymentType>().HasData(bank, momo);

            //Initialize Material Type
            MaterialType software = new MaterialType()
            {
                Name = "Software",
                UpdateAt = DateTime.Now,
            };
            MaterialType plugin = new MaterialType()
            {
                Name = "Plugin",
                UpdateAt = DateTime.Now,
            };
            MaterialType font = new MaterialType()
            {
                Name = "Font",
                UpdateAt = DateTime.Now,
            };
            MaterialType element = new MaterialType()
            {
                Name = "Element",
                UpdateAt = DateTime.Now,
            };
            MaterialType sound = new MaterialType()
            {
                Name = "Sound",
                UpdateAt = DateTime.Now,
            };
            modelBuilder.Entity<MaterialType>().HasData(software, plugin, font, element, sound);

            
        }
    }
}
