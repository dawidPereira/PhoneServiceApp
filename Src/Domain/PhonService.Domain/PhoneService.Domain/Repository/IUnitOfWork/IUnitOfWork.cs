using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        Task<bool> CompleteAsync();
    }
}
