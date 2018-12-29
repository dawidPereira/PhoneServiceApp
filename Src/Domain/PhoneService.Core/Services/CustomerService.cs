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
using PhoneService.Core.Services.Healpers;
using PhoneService.Core.Interfaces;

namespace PhoneService.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;
        private readonly SearchFilterHealpers _searchFilterHealpers;
        private readonly IEmailSender _emailSender;

        public CustomerService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod, SearchFilterHealpers searchFilterHealpers, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
            _searchFilterHealpers = searchFilterHealpers;
            _emailSender = emailSender;
        }

        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            var customers = await _unitOfWork.Customers.GetAllCustomersAsync();

            _nullCheckMethod.CheckIfResponseListIsEmpty(customers);

            var customersResponse = Mapper.Map<IEnumerable<CustomerResponse>>(customers);
            return customersResponse;
        }

        public async Task<IEnumerable<CustomerResponse>> GetCustomerBySearchTermsAsync(CustomerSearchRequest searchRequest)
        {
            var searchFilter = Mapper.Map<Customer>(searchRequest);
            var customers = await _unitOfWork.Customers.GetCustomerBySearchTermsAsync(searchFilter);

            _nullCheckMethod.CheckIfResponseListIsEmpty(customers);

            var response = Mapper.Map<IEnumerable<CustomerResponse>>(customers);

            return response;
        }

        public async Task<CustomerDetailsResponse> GetCustomerByIdAsync(int customerId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerId);

            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerId);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            var customerResponse = Mapper.Map<CustomerDetailsResponse>(customer);
            return customerResponse;
        }

        public async Task AddCustomerAsync(CustomerAddRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var customer = await _unitOfWork.Customers.GetCustomerByEmailAsync(customerRequest.Email);

            _nullCheckMethod.CheckIFObjectAlreadyExist(customer);

            var _customerRequest = Mapper.Map<Customer>(customerRequest);

            _unitOfWork.Customers.AddCustomer(_customerRequest);
            await _unitOfWork.CompleteAsync();
            

            //TODO: Run IEmailService and notifi user
        }

        public async Task UpdateCustomerAsync(CustomerUpdateRequest customerRequest)
        {
            _nullCheckMethod.CheckIfRequestIsNull(customerRequest);

            var customer = await _unitOfWork.Customers.GetCustomerByIdAsync(customerRequest.CustomerId);

            _nullCheckMethod.CheckIfResponseIsNull(customer);

            var customerAddresId = customer.Addres.CustomerAddresId;

            customer = Mapper.Map<CustomerUpdateRequest, Customer>(customerRequest);

            customer.Addres.CustomerAddresId = customerAddresId;

            _unitOfWork.Customers.UpdateCustomer(customer);
            await _unitOfWork.CompleteAsync();

            var repair = await _unitOfWork.Repairs.GetRepairItemByIdAsync(1);

            await _emailSender.SendRepairStatusChangeEmailAsync("StatusChangeTemplate.html", repair);
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
