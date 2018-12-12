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
        public UnitOfWork(PhoneServiceDbContext context)
        {
            this._context = context;
            Customers = new CustomerRepository(_context);
            //TODO: Add rest repo connection
        }
        
        public ICustomerRepository Customers { get; private set; }

        public async Task<bool> CompleteAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
