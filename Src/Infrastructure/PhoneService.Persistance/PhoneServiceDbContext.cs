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
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<EmailSubject> EmailSubjects { get; set; }

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
                new Customer { CustomerId = 1, Email = "pereiradawid@example.com", Name = "Dawid", LastName = "Pereira", PhoneNum = "781 361 182", TaxNum = "91032298349" },
                new Customer { CustomerId = 2, Email = "maksymilainmatula@example.com", Name = "Maksymilian", LastName = "Matuła", PhoneNum = "685 432 234", TaxNum = "89022338243" },
                new Customer { CustomerId = 3, Email = "miloszwinnicki@example.com", Name = "Miłosz", LastName = "Winnicki", PhoneNum = "783 234 432", TaxNum = "88113029383" },
                new Customer { CustomerId = 4, Email = "rafalpasek@example.com", Name = "Rafał", LastName = "Pasek", PhoneNum = "984 343 234", TaxNum = "94022829304" },
                new Customer { CustomerId = 5, Email = "grzegorzwojcik@example.com", Name = "Grzegorz", LastName = "Wójcik", PhoneNum = "745 543 321", TaxNum = "90010129348" },
                new Customer { CustomerId = 6, Email = "zbigniewwolski@example.com", Name = "Zbigniew", LastName = "Wolski", PhoneNum = "500 433 333", TaxNum = "70071429378" },
                new Customer { CustomerId = 7, Email = "tomaszbrzyski@example.com", Name = "Tomasz", LastName = "Brzyski", PhoneNum = "678 432 342", TaxNum = "66052229304" },
                new Customer { CustomerId = 8, Email = "monikazawadzka@example.com", Name = "Monika", LastName = "Zawadzka", PhoneNum = "787 438 282", TaxNum = "99011039456" },
                new Customer { CustomerId = 9, Email = "zofiawlodarczyk@example.com", Name = "Zofia", LastName = "Włodarczyk", PhoneNum = "378 392 234", TaxNum = "51031993845" },
                new Customer { CustomerId = 10, Email = "nataliabudzinska@example.com", Name = "Natalia", LastName = "Brudzińska", PhoneNum = "878 984 774", TaxNum = "87083095743" },
                new Customer { CustomerId = 11, Email = "emanuelmazowiecki@example.com", Name = "Emanuel", LastName = "Mazowiecki", PhoneNum = "577 573 572", TaxNum = "98070574834" },
                new Customer { CustomerId = 12, Email = "ewelinadobkowska@example.com", Name = "Ewelina", LastName = "Dobkowska", PhoneNum = "675 584 994", TaxNum = "65091138596" });

            modelBuilder.Entity<CustomerAddres>().HasData(
                new CustomerAddres { CustomerAddresId = 1, Adress = "Maćkówka 155", City = "Przeworsk", PostCode = "37-200", CustomerId = 1 },
                new CustomerAddres { CustomerAddresId = 2, Adress = "Zawiła 12", City = "Dąbrowa Górnicza", PostCode = "43-204", CustomerId = 2 },
                new CustomerAddres { CustomerAddresId = 3, Adress = "Przy Torze 3", City = "Rzeszów", PostCode = "35-356", CustomerId = 3 },
                new CustomerAddres { CustomerAddresId = 4, Adress = "Zaczernie 23", City = "Sosnowiec", PostCode = "30-300", CustomerId = 4 },
                new CustomerAddres { CustomerAddresId = 5, Adress = "1000-lecia 89", City = "Żwirki i Muchomorki", PostCode = "11-222", CustomerId = 5 },
                new CustomerAddres { CustomerAddresId = 6, Adress = "Powstańców Warszawy 56", City = "Rzeszów", PostCode = "25-567", CustomerId = 6 },
                new CustomerAddres { CustomerAddresId = 7, Adress = "Tadeusza Kościuszki 558", City = "Rzeszów", PostCode = "45 -432", CustomerId = 7 },
                new CustomerAddres { CustomerAddresId = 8, Adress = "Wesoła 11", City = "Łańcut", PostCode = "94-675", CustomerId = 8 },
                new CustomerAddres { CustomerAddresId = 9, Adress = "Zarzecze 87", City = "Tarnów", PostCode = "65-987", CustomerId = 9 },
                new CustomerAddres { CustomerAddresId = 10, Adress = "Osiedle Spokojna Dolina 23", City = "Jarosław", PostCode = "45-342", CustomerId = 10 },
                new CustomerAddres { CustomerAddresId = 11, Adress = "Kolorowa 93", City = "Przemyśl", PostCode = "43-432", CustomerId = 11 },
                new CustomerAddres { CustomerAddresId = 12, Adress = "Podgórze 9", City = "Rzeszów", PostCode = "21-765", CustomerId = 12 });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Producer = "Samsung", Model = "S8", Description = "Nie wiem po co nam opis produktu" },
                new Product { ProductId = 2, Producer = "Nokia", Model = "3310", Description = "Mam wrażenie, że trzeba usunąć opis" },
                new Product { ProductId = 3, Producer = "Xiaomi", Model = "Mi 8", Description = "Przepraszam czy to pomyłka" },
                new Product { ProductId = 4, Producer = "Redmi", Model = "4A", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 5, Producer = "Huwawei", Model = "P20", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 6, Producer = "Sony", Model = "Xperia 10", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 7, Producer = "PocoPhone", Model = "X1", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 8, Producer = "HTC", Model = "Desire 10", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 9, Producer = "Apple", Model = "X", Description = "Policja? - Proszę przyjechać na facebooka" },
                new Product { ProductId = 10, Producer = "Sony Ericson", Model = "SE6", Description = "Co jam ma tu wpisać ?" });

            modelBuilder.Entity<SaparePart>().HasData(
                new SaparePart { SaparePartId = 1, Name = "Wyświetlacz 5,5 cala", ReferenceNumber = "253FG32", Price = 150, },
                new SaparePart { SaparePartId = 2, Name = "Wyświetlacz 6,5 cala", ReferenceNumber = "2352s32", Price = 220, },
                new SaparePart { SaparePartId = 3, Name = "Powłoka ochronna 5,5 cala", ReferenceNumber = "23XX32", Price = 18, },
                new SaparePart { SaparePartId = 4, Name = "Powłoka ochronna 6,5 cala", ReferenceNumber = "5DS352", Price = 22, },
                new SaparePart { SaparePartId = 5, Name = "Bateria 2200 mAh", ReferenceNumber = "5DS352", Price = 180, },
                new SaparePart { SaparePartId = 6, Name = "Bateria 3000 mAh", ReferenceNumber = "5DS352", Price = 275, },
                new SaparePart { SaparePartId = 7, Name = "Pokrowiec ochronny 5,5 cala", ReferenceNumber = "5DS352", Price = 29, },
                new SaparePart { SaparePartId = 8, Name = "Pokrowiec ochronny 6,5 cala", ReferenceNumber = "5DS352", Price = 49, },
                new SaparePart { SaparePartId = 9, Name = "Ładowarka", ReferenceNumber = "5DS352", Price = 49, },
                new SaparePart { SaparePartId = 10, Name = "Spersonalizowane Etui", ReferenceNumber = "5DS352", Price = 149, });

            modelBuilder.Entity<ProductSaparePart>().HasData(
                new ProductSaparePart { ProductId = 1, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 5 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 7 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 1, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 2, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 3, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 4, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 5 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 7 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 5, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 6, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 5 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 7 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 7, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 8, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 1 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 3 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 5 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 7 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 9, SaparePartId = 10 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 2 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 4 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 6 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 8 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 9 },
                new ProductSaparePart { ProductId = 10, SaparePartId = 10 });

            modelBuilder.Entity<RepairStatus>().HasData(

                new RepairStatus { RepairStatusId = 1, Name = "Przyjeta" },
                new RepairStatus { RepairStatusId = 2, Name = "Wyceniona" },
                new RepairStatus { RepairStatusId = 3, Name = "W trakcie realizacji" },
                new RepairStatus { RepairStatusId = 4, Name = "Zrealizowana" },
                new RepairStatus { RepairStatusId = 5, Name = "Zakończona" },
                new RepairStatus { RepairStatusId = 6, Name = "Odrzucona" },
                new RepairStatus { RepairStatusId = 7, Name = "Zakończona bez naprawy" });

            modelBuilder.Entity<Repair>().HasData(
                new Repair { RepairId = 1, CustomerId = 1, ProductId = 1, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Klient zgłasza problem z krótkim czasem pracy telefonu" },
                new Repair { RepairId = 2, CustomerId = 1, ProductId = 5, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Po aktualizacji systemu, telefon znacznie spowolnił. Pojawiają się błędy graficzne, a telefon się przegrzewa" },
                new Repair { RepairId = 3, CustomerId = 2, ProductId = 2, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Klient nie może dodzwonić się do nikogo" },
                new Repair { RepairId = 4, CustomerId = 3, ProductId = 3, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Klientowi nie działa klawiatura" },
                new Repair { RepairId = 5, CustomerId = 3, ProductId = 4, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Popsuty głośnik" },
                new Repair { RepairId = 6, CustomerId = 4, ProductId = 1, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Telefon został zalany przez klienta. Po zdarzeniu przestał działać wyświetlacz oraz głośnik" },
                new Repair { RepairId = 7, CustomerId = 5, ProductId = 2, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Klient serwisował telefon u konkurencji, naprawa nie odniosła pozytynego skutku. Zgłosił sie do nas z prośba o rozwiązanie problemu z niedziałajacą baterią, oraz z prosbą o personalizację etiu." },
                new Repair { RepairId = 8, CustomerId = 5, ProductId = 5, RepairStatusId = 1, CreateDate = DateTime.UtcNow, Description = "Klient prosi o szybki czas realizacji" });

            modelBuilder.Entity<EmailSubject>().HasData(
                new EmailSubject { EmailSubjectId = 1, Subject = "Twoja naprawa została wyceniona" },
                new EmailSubject { EmailSubjectId = 2, Subject = "Twoja naprawa została przekazana do realizacji" },
                new EmailSubject { EmailSubjectId = 3, Subject = "Status Twojej naprawy został zmieniony" },
                new EmailSubject { EmailSubjectId = 4, Subject = "Twój telefon jest gotowy do odbioru" },
                new EmailSubject { EmailSubjectId = 5, Subject = "Zarejestrowaliśmy Twoją naprawę" },
                new EmailSubject { EmailSubjectId = 6, Subject = "Twoje konto zostało zarejestrowane" }
                );

            modelBuilder.Entity<EmailTemplate>().HasData(
                new EmailTemplate { EmailTemplateId = 1, TemplateName = "StatusChangeTemplate.html" },
                new EmailTemplate { EmailTemplateId = 2, TemplateName = "CustomerDecisionTemplate.html" },
                new EmailTemplate { EmailTemplateId = 3, TemplateName = "RepairAddTemplate.html" },
                new EmailTemplate { EmailTemplateId = 4, TemplateName = "CustomerCreateTemplate.html" }
                );

            #endregion
        }


    }
}
