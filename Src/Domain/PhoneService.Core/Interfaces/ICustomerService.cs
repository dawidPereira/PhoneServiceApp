using PhoneService.Core.Models;
using PhoneService.Core.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();

        Task<IEnumerable<CustomerResponse>> GetCustomerBySearchTermsAsync(CustomerSearchRequest searchRequest);

        Task<CustomerDetailsResponse> GetCustomerByIdAsync(int customerId);

        Task AddCustomerAsync(CustomerAddRequest customerRequest);

        Task UpdateCustomerAsync(CustomerUpdateRequest customerRequest);

        Task RemoveCustomerAsync(int customerId);

    }
}