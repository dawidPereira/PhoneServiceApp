using Microsoft.EntityFrameworkCore.Internal;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneService.Persistance
{
    public class PhoneServiceInitializer
    {
        private readonly Dictionary<int, Customer> Customers = new Dictionary<int, Customer>();
        private readonly Dictionary<int, CustomerAddres> CustomersAddres = new Dictionary<int, CustomerAddres>();
        private readonly Dictionary<int, Repair> Repairs = new Dictionary<int, Repair>();
        private readonly Dictionary<int, RepairStatus> RepairStatuses = new Dictionary<int, RepairStatus>();
        private readonly Dictionary<int, Product> Products = new Dictionary<int, Product>();
        private readonly Dictionary<int, SaparePart> ShaperParts = new Dictionary<int, SaparePart>();
        private readonly Dictionary<int, SaparePartItem> ShaperPartItems = new Dictionary<int, SaparePartItem>();

        public static void Initialize(PhoneServiceDbContext context)
        {
            var initializer = new PhoneServiceInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(PhoneServiceDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return; // Db has been seeded
            }

            SeedCustomerAddres(context);

            SeedProduct(context);

            SeedRepairStatus(context);

            SeedSaparePart(context);

            SeedCustomer(context);

            SeedRepairs(context);

            context.SaveChanges();

        }

        public void SeedCustomerAddres(PhoneServiceDbContext context)
        {
            var customerAddres = new[]
            {
                new CustomerAddres {CustomerAddresId = 1, City = "Rzeszów", Adress = "Moj adres 11", PostCode = "33-221"}
            };

            context.CustomerAddres.AddRange(customerAddres);
        }
        public void SeedProduct(PhoneServiceDbContext context)
        {
            var product = new[]
            {
                new Product {ProductId = 1, Model = "Moj model", Producer = "Samsung", Description = "To jest opis mojego produktu" }
            };

            context.Products.AddRange(product);
        }

        public void SeedRepairStatus(PhoneServiceDbContext context)
        {
            var repairStatus = new[]
            {
                new RepairStatus { RepairStatusId = 1, Name = "Pirwszy status" }
            };

            context.RepairStatuses.AddRange(repairStatus);
        }
        public void SeedSaparePart(PhoneServiceDbContext context)
        {
            var saparePart = new[]
            {
                new SaparePart { SaparePartId = 1, Name = "Moja część", Price = 20, ReferenceNumebr = "2121ewq12" }
            };

            context.SapareParts.AddRange(saparePart);
        }

        public void SeedCustomer(PhoneServiceDbContext context)
        {
            var customer = new[]
            {
                new Customer {CustomerId = 1, Name = "Dawid", LastName = "Pereira" }
            };

            context.Customers.AddRange(customer);
        }

        public void SeedRepairs(PhoneServiceDbContext context)
        {
            var repairs = new[]
            {
                new Repair { RepairId = 1, }
            };

            context.Repairs.AddRange(repairs);
        }
    }
}
