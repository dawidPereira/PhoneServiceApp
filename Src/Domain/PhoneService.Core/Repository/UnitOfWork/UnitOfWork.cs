using PhoneService.Core.Services.Healpers;
using PhoneService.Domain.Repository;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PhoneServiceDbContext _context;
        private readonly SearchFilterHealpers _searchFilterHealpers;
        public UnitOfWork(PhoneServiceDbContext context, SearchFilterHealpers searchFilterHealpers)
        {
            _context = context;
            _searchFilterHealpers = searchFilterHealpers;
            Customers = new CustomerRepository(_context, _searchFilterHealpers);
            SapareParts = new SaparePartRepository(_context);
            Products = new ProductRepository(_context, _searchFilterHealpers);
            Repairs = new RepairRepository(_context, _searchFilterHealpers);
            RepairItems = new RepairItemRepository(_context);
            //TODO: Add rest repo connection
        }
        
        public ICustomerRepository Customers { get; private set; }
        public ISaparePartRepository SapareParts { get; private set; }
        public IProductRepository Products { get; private set; }
        public IRepairRepository Repairs { get; private set; }
        public IRepairItemRepository RepairItems { get; private set; }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
