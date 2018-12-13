using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(int customerId);

        Task<Customer> GetCustomerByCustomerObject(Customer customer);

        Task<Customer> GetCustomerByEmailAsync(string email);

        void AddCustomer(Customer customer);

        void RemoveCustomer(Customer customer);
    }
}
