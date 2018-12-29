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
        Task SendRepairStatusChangeEmailAsync(string templateName, string subject, RepairDetailsResponse repair);
    }
}
