using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PhoneService.Persistance
{
    public class PhoneServiceDbContext : DbContext
    {
        public PhoneServiceDbContext(DbContextOptions<PhoneServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddres> CustomerAddres { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<RepairStatus> RepairStatuses { get; set; }
        public DbSet<SaparePart> SapareParts { get; set; }
        public DbSet<SaparePartItem> SaparePartItems { get; set; }
        public DbSet<ProductSaparePart> ProductSapareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
            modelBuilder.Entity<ProductSaparePart>()
                .HasKey(p => new
                {
                    p.ProductId,
                    p.SaparePartId
                });
            modelBuilder.Entity<ProductSaparePart>()
                .HasOne<Product>(p => p.Product)
                .WithMany(psp => psp.ProductSapareParts)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductSaparePart>()
                .HasOne<SaparePart>(sp => sp.SaparePart)
                .WithMany(psp => psp.ProductSapareParts)
                .HasForeignKey(sp => sp.SaparePartId);

            modelBuilder.Entity<SaparePartItem>()
                .HasMany(c => c.SapareParts)
                .WithOne(e => e.SaparePartItems);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Addres)
                .WithOne(e => e.Customer)
                .HasForeignKey<CustomerAddres>(cb => cb.CustomerAddresId);




        }


}
}
