using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public DbSet<RepairItem> RepairItems { get; set; }
        public DbSet<ProductSaparePart> ProductSapareParts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set SQL Conenction
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PhoneService;Trusted_Connection=True;Application Name=PhoneServiceDatabase;");
            
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

            #region Setting entities relationships

            //############################################
            // Product - SaparePart Join Table Connection
            //############################################

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

            //############################################
            // RepairItem Join Table Connection
            //############################################

            modelBuilder.Entity<RepairItem>()
                .HasKey(p => new
                {
                    p.RepairId,
                    p.SaparePartId
                });
            modelBuilder.Entity<RepairItem>()
                .HasOne<Repair>(p => p.Repair)
                .WithMany(psp => psp.RepairItems)
                .HasForeignKey(p => p.RepairId);

            modelBuilder.Entity<RepairItem>()
                .HasOne<SaparePart>(sp => sp.SaparePart)
                .WithMany(psp => psp.RepairItems)
                .HasForeignKey(sp => sp.SaparePartId);

            #endregion
        }


    }
}
