using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneService.Core
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly PhoneServiceDbContext _context;

        public GetCustomersListQueryHandler(PhoneServiceDbContext context)
        {
            _context = context;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var vm = new CustomersListViewModel
            {
                Customers = await _context.Customers.Select(c =>
                    new CustomerLookupModel
                    {
                        Id = c.CustomerId.ToString(),
                        FirstName = c.Name,
                        LastName = c.LastName
                    }).ToListAsync(cancellationToken)
            };

            return vm;
        }

        
    }
}

