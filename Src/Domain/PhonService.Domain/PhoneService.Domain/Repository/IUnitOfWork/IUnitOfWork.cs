using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        ISaparePartRepository SapareParts { get; }
        IProductRepository Products { get; }
        IRepairRepository Repairs { get; }
        IRepairItemRepository RepairItems { get; }
        IEmailSubjectRepository EmailSubject { get; }
        IEmailTemplateRepository EmailTemplate { get; }
        Task CompleteAsync();
    }
}
