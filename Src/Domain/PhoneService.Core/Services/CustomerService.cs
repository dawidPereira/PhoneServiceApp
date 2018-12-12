using AutoMapper;
using PhoneService.Core.Models;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllCustomersAsync();

            if (customers == null)
                throw new ArgumentNullException("Customer List is Empty");
            var x = Mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return x;
        }

        public async Task<CustomerDetailsResponse> GetCustomerByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveCustomerAsync()
        {
            throw new NotImplementedException();
        }
    }
}
