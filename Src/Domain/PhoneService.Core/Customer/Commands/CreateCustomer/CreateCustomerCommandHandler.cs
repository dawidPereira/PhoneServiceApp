using MediatR;
using PhoneService.Domain;
using PhoneService.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneService.Core
{

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
        {
            private readonly PhoneServiceDbContext _context;

            public CreateCustomerCommandHandler(
                PhoneServiceDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
            var entity = new Customer
            {
                CustomerId = request.CustomerId,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNum = request.PhoneNum,
                TaxNum = request.TaxNum,
                Addres = new CustomerAddres { City = "Rzeszow" }
            };

            _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

  
    }
    

}
