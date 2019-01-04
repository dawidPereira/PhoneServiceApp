using PhoneService.Core.Models.Customer;
using PhoneService.Core.Models.Healpers;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendRepairStatusChangeEmailAsync(string templateName, string subject, RepairDetailsResponse repair, CustomerDecisionLink links);
        Task SendRepairAddNotifyEmailAsync(string templateName, string subject, RepairDetailsResponse repair);
        Task SendCustomerAddNotifyEmailAsync(string templateName, string subject, CustomerDetailsResponse custoemr);
    }
}
