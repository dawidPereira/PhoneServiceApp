using PhoneService.Domain.Repository;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Repository
{
    public class RepairRepository : IRepairRepository
    {
        protected readonly PhoneServiceDbContext _context;

        public RepairRepository(PhoneServiceDbContext context) => _context = context;
    }
}
