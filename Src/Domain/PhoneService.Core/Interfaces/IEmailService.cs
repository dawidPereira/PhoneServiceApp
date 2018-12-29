using PhoneService.Core.Models.Repair;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Interfaces
{
    public interface IEmailService
    {
        Task SendRepairStatusNotifyEmailAsync(int repairId);
    }
}
