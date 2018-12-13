using PhoneService.Core.Models;
using PhoneService.Core.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();

        Task<CustomerDetailsResponse> GetCustomerByIdAsync(int customerId);

        Task AddCustomerAsync(CustomerRequest customerRequest);

        Task UpdateCustomerAsync(CustomerRequest customerRequest);

        Task RemoveCustomerAsync(int customerId);

    }
}