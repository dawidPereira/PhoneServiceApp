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
        public DbSet<SaparePartItem> SaparePartItems { get; set; }
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
            // Product - Repair Join Table Connection
            //############################################
            modelBuilder.Entity<RepairProduct>()
                .HasKey(p => new
                {
                    p.RepairId,
                    p.ProductId
                });
            modelBuilder.Entity<RepairProduct>()
                .HasOne<Product>(p => p.Product)
                .WithMany(rp => rp.RepairProducts)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<RepairProduct>()
                .HasOne<Repair>(r => r.Repair)
                .WithMany(rp => rp.RepairProducts)
                .HasForeignKey(r => r.RepairId);

            //############################################
            // Customer - Repair Join Table Connection
            //############################################
            modelBuilder.Entity<CustomerRepair>()
                .HasKey(p => new
                {
                    p.RepairId,
                    p.CustomerId
                });
            modelBuilder.Entity<CustomerRepair>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(cr => cr.CustomerRepairs)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<CustomerRepair>()
                .HasOne<Repair>(r => r.Repair)
                .WithMany(ce => ce.CustomerRepairs)
                .HasForeignKey(r => r.RepairId);

            //############################################
            // SaparePart - SaparePartItem Join Table Connection
            //############################################
            modelBuilder.Entity<SaparePartSaparePartItem>()
                .HasKey(p => new
                {
                    p.SaparePartId,
                    p.SaparePartItemId
                });
            modelBuilder.Entity<SaparePartSaparePartItem>()
                .HasOne<SaparePart>(sp => sp.SaparePart)
                .WithMany(spspi => spspi.SaparePartSaparePartItems)
                .HasForeignKey(sp => sp.SaparePartId);

            modelBuilder.Entity<SaparePartSaparePartItem>()
                .HasOne<SaparePartItem>(spi => spi.SaparePartItem)
                .WithMany(spspi => spspi.SaparePartSaparePartItems)
                .HasForeignKey(spi => spi.SaparePartItemId);

            //############################################
            // Customer - Customer Addres One To One
            //############################################
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Addres)
                .WithOne(e => e.Customer)
                .HasForeignKey<CustomerAddres>(cb => cb.CustomerId);


            //############################################
            // Repair - RepairStatus Many To One
            //############################################
            modelBuilder.Entity<RepairStatus>()
                .HasMany(r => r.Repairs)
                .WithOne(rs => rs.RepairStatus);

            //############################################
            // Repair - RepairStatus Many To One
            //############################################
            modelBuilder.Entity<Repair>()
                .HasMany(r => r.SaparePartItems)
                .WithOne(rs => rs.Repair);
            #endregion



        }


    }
}
