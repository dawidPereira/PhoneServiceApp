using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhoneService.Core.Services.Healpers;
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
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly PhoneServiceDbContext _context;
        protected readonly SearchFilterHealpers _searchFilterHealpers;

        public CustomerRepository(PhoneServiceDbContext context, SearchFilterHealpers searchFilterHealpers)
        {
            _context = context;
            _searchFilterHealpers = searchFilterHealpers;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var customers = await _context.Set<Customer>()
                                    .OrderByDescending(c => c.CustomerId)
                                    .ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Set<Customer>()
                            .Include(c => c.Addres)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerBySearchTermsAsync(Customer customer)
        {
            IEnumerable<Customer> customers = _context.Set<Customer>()
                                .Include(c => c.Addres)
                                .AsQueryable()
                                .OrderByDescending(c => c.CustomerId);

            var searchResponse = await _searchFilterHealpers.SearchByContains(customers, customer);
            var response = Mapper.Map<IEnumerable<Customer>>(searchResponse);

            return response;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customer = await _context.Set<Customer>()
                            .FirstOrDefaultAsync(c => c.Email == email);

            return customer;
        }

        public void AddCustomer(Customer customer) => _context.Add(customer);
        
        public void UpdateCustomer(Customer customer) => _context.Update(customer);

        public void RemoveCustomer(Customer customer) => _context.Remove(customer);
    }
}
