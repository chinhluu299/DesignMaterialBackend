using DesignMaterialBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace DesignMaterialBackend.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid guid1 = new Guid("4b3d1bda-7a32-406a-868f-2c07f27607b4");
            Guid guid2 = new Guid("fd5ed73b-81a3-4a2b-ba9f-73a2a491b1d6");
            Guid guid3 = new Guid("b457ef8e-3371-4b59-8f46-a1ddfe18b10f");
            Guid guid4 = new Guid("d7296a15-fa42-4f7b-b70f-066fae86a83b");
            Guid guid5 = new Guid("1297b179-a53b-4744-b972-2d89052a8579");
            Guid guid6 = new Guid("5b541003-b171-4c4b-b2a7-bc91b71fd81f");
            Guid guid7 = new Guid("19713c48-f765-4767-a740-97016453f68b");
            Guid guid8 = new Guid("7669e3da-034c-496f-bfb6-bd4f4d18146e");
            Guid guid9 = new Guid("3d08304c-8fea-4889-9112-12e432aecf8d");
            Guid guid10 = new Guid("b927141a-f4b7-41ea-884e-f3f24828276f");
            // Initialize Currency Unit
            CurrencyUnit vndUnit = new CurrencyUnit()
            {
                Id = guid1,
                Unit = "VND",
                Description = "Vietnamese Dong",
                CreateAt = DateTime.Now,
            };
            modelBuilder.Entity<CurrencyUnit>().HasData(vndUnit);

            //Exchange Rate
            ExchangeRate vndRate = new ExchangeRate()
            {
                Id = guid2,
                Active = true,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
                Rate = 1000,
                CurrencyUnitId = vndUnit.Id,

            };
            modelBuilder.Entity<ExchangeRate>().HasData(vndRate);

            //Initialize Payment Type
            PaymentType momo = new PaymentType()
            {
                Id = guid3,
                Name = "Momo",
                Description = "",
                IsOnline = true
            };
            PaymentType bank = new PaymentType()
            {
                Id = guid4,
                Name = "Banking",
                Description = "",
                IsOnline = true
            };
            modelBuilder.Entity<PaymentType>().HasData(bank, momo);

            //Initialize Material Type
            MaterialType software = new MaterialType()
            {
                Id = guid5,
                Name = "Software",
                UpdateAt = DateTime.Now,
            };
            MaterialType plugin = new MaterialType()
            {
                Id = guid6,
                Name = "Plugin",
                UpdateAt = DateTime.Now,
            };
            MaterialType font = new MaterialType()
            {
                Id = guid7,
                Name = "Font",
                UpdateAt = DateTime.Now,
            };
            MaterialType element = new MaterialType()
            {
                Id = guid8,
                Name = "Element",
                UpdateAt = DateTime.Now,
            };
            MaterialType sound = new MaterialType()
            {
                Id = guid9,
                Name = "Sound",
                UpdateAt = DateTime.Now,
            };
            modelBuilder.Entity<MaterialType>().HasData(software, plugin, font, element, sound);

            
        }
    }
}
