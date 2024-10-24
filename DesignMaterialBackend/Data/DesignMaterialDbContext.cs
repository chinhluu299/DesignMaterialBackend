﻿using DesignMaterialBackend.Data.Configurations;
using DesignMaterialBackend.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DesignMaterialBackend.Data
{
    public class DesignMaterialDbContext : IdentityDbContext<User,IdentityRole<Guid> ,Guid>
    {
        public DesignMaterialDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CurrencyUnit> CurrencyUnits { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);



        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<User>(new UserConfiguration());
            builder.ApplyConfiguration<Receipt>(new ReceiptConfiguration());
            builder.ApplyConfiguration<Material>(new MaterialConfiguration());
            builder.ApplyConfiguration<MaterialType>(new MaterialTypeConfiguration());
            builder.ApplyConfiguration<PaymentAccount>(new PaymentAccountConfiguration());
            builder.ApplyConfiguration<PaymentType>(new PaymentTypeConfiguration());
            builder.ApplyConfiguration<CurrencyUnit>(new CurrencyUnitConfiguration());
            builder.ApplyConfiguration<ExchangeRate>(new ExchangeRateConfiguration());
            builder.ApplyConfiguration<Blog>(new BlogConfiguration());
            builder.ApplyConfiguration<BlogCategory>(new BlogCategoryConfiguration());

            builder.Seed();
     
        }
    }
}
