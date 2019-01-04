using PhoneService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository
{
    public interface IEmailSubjectRepository
    {
        Task<EmailSubject> GetEmailSubjectByIdAsync(int emailSubjectId);
    }
}
