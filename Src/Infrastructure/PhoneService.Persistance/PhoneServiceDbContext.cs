using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PhoneService.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PhoneService.Persistance
{
    public class PhoneServiceDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
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
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyAllConfigurations();
            base.OnModelCreating(modelBuilder);

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

            #region Seed Data

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Email = "pereiradawid@example.com", Name = "Dawid", LastName = "Pereira", PhoneNum = "123456789", TaxNum = "987654321" },
                new Customer { CustomerId = 2, Email = "maksymilainmatula@example.com", Name = "Maksymilian", LastName = "Matuła", PhoneNum = "123456789", TaxNum = "987654321" },
                new Customer { CustomerId = 3, Email = "miloszwinnicki@example.com", Name = "Miłosz", LastName = "Winnicki", PhoneNum = "123456789", TaxNum = "987654321" },
                new Customer { CustomerId = 4, Email = "rafalpasek@example.com", Name = "Rafał", LastName = "Pasek", PhoneNum = "123456789", TaxNum = "987654321" },
                new Customer { CustomerId = 5, Email = "grzegorzwojcik@example.com", Name = "Grzegorz", LastName = "Wójcik", PhoneNum = "123456789", TaxNum = "987654321" });

            modelBuilder.Entity<CustomerAddres>().HasData(
                new CustomerAddres { CustomerAddresId = 1, City = "Przeworsk", PostCode = "37-200", CustomerId = 1 },
                new CustomerAddres { CustomerAddresId = 2, City = "Dąbrowa Górnicza", PostCode = "43-204", CustomerId = 2 },
                new CustomerAddres { CustomerAddresId = 3, City = "Rzeszów", PostCode = "35-356", CustomerId = 3 },
                new CustomerAddres { CustomerAddresId = 4, City = "Sosnowiec", PostCode = "30-300", CustomerId = 4 },
                new CustomerAddres { CustomerAddresId = 5, City = "Żwirki i Muchomorki", PostCode = "11-222", CustomerId = 5 });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Producer = "Samsung", Model = "S8", Description = "Nie wiem po co nam opis produktu" },
                new Product { ProductId = 2, Producer = "Nokia", Model = "3310", Description = "Mam wrażenie, że trzeba usunąć opis" },
                new Product { ProductId = 3, Producer = "Xiaomi", Model = "Lepszy", Description = "Przepraszam czy to pomyłka" },
                new Product { ProductId = 4, Producer = "Apple", Model = "XXX", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 5, Producer = "Sony Ericson", Model = "Ericson Sony", Description = "Co jam ma tu wpisać ?" });

            modelBuilder.Entity<SaparePart>().HasData(
                new SaparePart { SaparePartId = 1, Name = "Dioda W34", Price = 10, },
                new SaparePart { SaparePartId = 2, Name = "Tranzystor BX11", Price = 10, },
                new SaparePart { SaparePartId = 3, Name = "Wyświetlacz uniwersalny", Price = 10, },
                new SaparePart { SaparePartId = 4, Name = "O co to za śróbka", Price = 10, },
                new SaparePart { SaparePartId = 5, Name = "Klawiatura 3310", Price = 10, });

            modelBuilder.Entity<ProductSaparePart>().HasData(
                new ProductSaparePart { ProductId = 1, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 5 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 3 });

            modelBuilder.Entity<RepairStatus>().HasData(
                new RepairStatus { RepairStatusId = 1, Name = "Przyjeta" },
                new RepairStatus { RepairStatusId = 2, Name = "Wyceniona" },
                new RepairStatus { RepairStatusId = 3, Name = "W trakcie realizacji" },
                new RepairStatus { RepairStatusId = 4, Name = "Zrealizowana" },
                new RepairStatus { RepairStatusId = 5, Name = "Zakończona" },
                new RepairStatus { RepairStatusId = 6, Name = "Odrzucona" },
                new RepairStatus { RepairStatusId = 7, Name = "Zakończona bez naprawy" });

            modelBuilder.Entity<Repair>().HasData(
                new Repair { RepairId = 1, CustomerId = 1, ProductId = 1, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Tutaj powinien być jakiś opis naprawy" },
                new Repair { RepairId = 2, CustomerId = 1, ProductId = 5, RepairStatusId = 2, CreateDate = DateTime.UtcNow, Description = "Opis z produktu dodamu tutaj" },
                new Repair { RepairId = 3, CustomerId = 2, ProductId = 2, RepairStatusId = 3, CreateDate = DateTime.UtcNow, Description = "Klient nie może dodzwonić się do nikogo - nie opłacił abonamentu" },
                new Repair { RepairId = 4, CustomerId = 3, ProductId = 3, RepairStatusId = 4, CreateDate = DateTime.UtcNow, Description = "Klientowi nie działa klawiatura" },
                new Repair { RepairId = 5, CustomerId = 3, ProductId = 4, RepairStatusId = 5, CreateDate = DateTime.UtcNow, Description = "Popsuty głośnik" },
                new Repair { RepairId = 6, CustomerId = 4, ProductId = 1, RepairStatusId = 6, CreateDate = DateTime.UtcNow, Description = "Klient przyniusł zalany telefon w skarpecie z ryżem" },
                new Repair { RepairId = 7, CustomerId = 5, ProductId = 2, RepairStatusId = 2, CreateDate = DateTime.UtcNow, Description = "Coś nie diała" },
                new Repair { RepairId = 8, CustomerId = 5, ProductId = 5, RepairStatusId = 6, CreateDate = DateTime.UtcNow, Description = "Pan nie był zadowolony" });

            #endregion
        }


    }
}
