using PhoneService.Domain;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(PhoneServiceDbContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await FindAllAsync();
            return customers;
        }
    }
}
