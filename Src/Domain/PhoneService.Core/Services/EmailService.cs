using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task SendRepairStatusNotifyEmail(RepairDetailsResponse repair)
        {

        }
    }
}
