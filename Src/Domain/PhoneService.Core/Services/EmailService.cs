using AutoMapper;
using PhoneService.Core.Interfaces;
using PhoneService.Core.Models.Repair;
using PhoneService.Domain;
using PhoneService.Domain.Entities;
using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;


        public EmailService(IEmailSender emailSender, IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod)
        {
            _emailSender = emailSender;
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
        }
        public async Task SendRepairStatusNotifyEmailAsync(int repairId)
        {
            var repair = await GetRepairByIdAsync(repairId);

            if (repair.StatusId == 2)
            {
                var subject = await _unitOfWork.EmailSubject.GetEmailSubjectByIdAsync(1);
                var emailTemplate = await _unitOfWork.EmailTemplate.GetEmailTemplateByIdAsync(1);

                await _emailSender.SendRepairStatusChangeEmailAsync(emailTemplate.TemplateName, subject.Subject, repair);
            }
            if (repair.StatusId == 3)
            {
                var subject = await _unitOfWork.EmailSubject.GetEmailSubjectByIdAsync(2);
                var emailTemplate = await _unitOfWork.EmailTemplate.GetEmailTemplateByIdAsync(1);

                await _emailSender.SendRepairStatusChangeEmailAsync(emailTemplate.TemplateName, subject.Subject, repair);
            }
            if (repair.StatusId == 4
                || repair.StatusId == 5
                || repair.StatusId == 6
                || repair.StatusId == 7)
            {
                var subject = await _unitOfWork.EmailSubject.GetEmailSubjectByIdAsync(4);
                var emailTemplate = await _unitOfWork.EmailTemplate.GetEmailTemplateByIdAsync(1);

                await _emailSender.SendRepairStatusChangeEmailAsync(emailTemplate.TemplateName, subject.Subject, repair);
            }
        }

        public async Task<RepairDetailsResponse> GetRepairByIdAsync(int repairId)
        {
            _nullCheckMethod.CheckIfRequestIsNull(repairId);

            var repair = await _unitOfWork.Repairs.GetRepairItemByIdAsync(repairId);

            _nullCheckMethod.CheckIfResponseIsNull(repair);

            var repairResponse = Mapper.Map<RepairDetailsResponse>(repair);

            return repairResponse;
        }
    }
}
