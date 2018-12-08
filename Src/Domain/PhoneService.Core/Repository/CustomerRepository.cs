using Microsoft.EntityFrameworkCore;
using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(PhoneServiceDbContext context)
        : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await FindAllAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await context.Customers
                            .Include(c => c.Addres)
                            .Where(c => c.CustomerId == id)
                            .FirstOrDefaultAsync();
            return customer;
        }
    }
}
