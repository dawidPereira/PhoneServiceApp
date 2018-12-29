using Microsoft.EntityFrameworkCore;
using PhoneService.Domain.Entities;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
       
            protected readonly PhoneServiceDbContext _context;

            public EmailTemplateRepository(PhoneServiceDbContext context)
            {
                _context = context;
            }
            public async Task<EmailTemplate> GetEmailTemplateByIdAsync(int emailTemplateId)
            {
                var emailTemplate = await _context.Set<EmailTemplate>()
                                    .FirstOrDefaultAsync(c => c.EmailTemplateId == emailTemplateId);

                return emailTemplate;
            }
    }
}
