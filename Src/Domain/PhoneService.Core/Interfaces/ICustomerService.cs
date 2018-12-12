using PhoneService.Core.Models;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();

        Task<CustomerDetailsResponse> GetCustomerByIdAsync();

        Task AddCustomerAsync();

        Task UpdateCustomerAsync();

        Task RemoveCustomerAsync();

    }
}
