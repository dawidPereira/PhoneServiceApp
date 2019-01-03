using Microsoft.EntityFrameworkCore;
using PhoneService.Domain.Entities;
using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Core.Repository
{
    public class EmailSubjectRepository : IEmailSubjectRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public EmailSubjectRepository(PhoneServiceDbContext context)
        {
            _context = context;
        }
        public async Task<EmailSubject> GetEmailSubjectByIdAsync(int emailSubjectId)
        {
            var emailSubject = await _context.Set<EmailSubject>()
                               .FirstOrDefaultAsync(c => c.EmailSubjectId == emailSubjectId);

            return emailSubject;
        }
    }
}
