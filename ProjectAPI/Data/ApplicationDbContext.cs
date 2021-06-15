using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ManufacturerDistribuitor>()
                .HasOne(m => m.Manufacturer)
                .WithMany(md => md.ManufacturerDistribuitors)
                .HasForeignKey(mi => mi.ManufacturerId);

            builder.Entity<ManufacturerDistribuitor>()
                .HasOne(d => d.Distribuitor)
                .WithMany(md => md.ManufactureDistribuitors)
                .HasForeignKey(di => di.DistribuitorId);

            builder.Entity<ProductDistribuitor>()
                .HasOne(p => p.Product)
                .WithMany(pd => pd.ProductDistribuitors)
                .HasForeignKey(pi => pi.ProductId);

            builder.Entity<ProductDistribuitor>()
                .HasOne(d => d.Distribuitor)
                .WithMany(pd => pd.ProductDistribuitors)
                .HasForeignKey(di => di.DistribuitorId);
        }
        public DbSet<Distribuitor> Distribuitors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ManufacturerDistribuitor> ManufacturerDistribuitors { get; set; }
        public DbSet<ProductDistribuitor> ProductDistribuitors { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<ImportLog> ImportLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
