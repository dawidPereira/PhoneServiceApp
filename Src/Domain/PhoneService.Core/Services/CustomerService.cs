using AutoMapper;
using PhoneService.Core.Models;
using PhoneService.Core.Models.Customer;
using PhoneService.Domain;
using PhoneService.Domain.Repository.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneService.Infrastructure.Common;

namespace PhoneService.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;

        public CustomerService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllCustomersAsync();

            _nullCheckMethod.CheckIfResponseListIsEmpty(customers);

            var customersResponse = Mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return customersResponse;
        }
        
        public async Task<CustomerDetailsResponse> GetCustomerByIdAsync(int customerId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerId);

            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            var customerResponse = Mapper.Map<CustomerDetailsResponse>(customer);
            return customerResponse;
        }

        public async Task AddCustomerAsync(CustomerRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var customer = await _unitOfWork.Customers.GetCustomerByEmail(customerRequest.Email);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            var _customerRequest = Mapper.Map<Customer>(customerRequest);

            _unitOfWork.Customers.AddCustomer(_customerRequest);
            await _unitOfWork.CompleteAsync();

            //TODO: Run IEmailService and notifi user
        }

        public async Task UpdateCustomerAsync(CustomerRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var customer = await _unitOfWork.Customers.GetCustomerByEmail(customerRequest.Email);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            Mapper.Map(customerRequest, customer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveCustomerAsync(int customerId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerId);

            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            _unitOfWork.Customers.RemoveCustomer(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
