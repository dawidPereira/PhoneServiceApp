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

namespace PhoneService.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllCustomersAsync();

            if (!customers.Any())
                throw new ArgumentNullException("Customer List is Empty");

            var customersResponse = Mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return customersResponse;
        }

        public async Task<CustomerDetailsResponse> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);

            if (customer == null)
                throw new ArgumentNullException("Customr does not exist");

            var customerResponse = Mapper.Map<CustomerDetailsResponse>(customer);
            return customerResponse;
        }

        public async Task AddCustomerAsync(CustomerRequest customerRequest)
        {
            if (customerRequest == null)
                throw new ArgumentNullException("Customer can not be empty");

            var customer = await _unitOfWork.Customers.GetCustomerByEmail(customerRequest.Email);

            if (customer != null)
                throw new ArgumentException("User with this email already exist");

            var _customerRequest = Mapper.Map<Customer>(customerRequest);

            _unitOfWork.Customers.AddCustomer(_customerRequest);
            await _unitOfWork.CompleteAsync();

            //TODO: Run IEmailService and notifi user
        }

        public async Task UpdateCustomerAsync(CustomerRequest customerRequest)
        {
            if (customerRequest == null)
                throw new ArgumentNullException("Customer can not be empty");

            var customer = await _unitOfWork.Customers.GetCustomerByEmail(customerRequest.Email);

            if (customer == null)
                throw new KeyNotFoundException("User does not exist");

            Mapper.Map<Customer>(customerRequest);
            await _unitOfWork.CompleteAsync();
        }

        public async Task RemoveCustomerAsync(int customerId)
        {
            if (customerId == null)
                throw new ArgumentNullException("Id can not be empty");
            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);

            if (customer == null)
                throw new KeyNotFoundException("This customer does not exist");

            _unitOfWork.Customers.RemoveCustomer(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
