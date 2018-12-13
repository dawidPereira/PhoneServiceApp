using PhoneService.Domain.Repository.IUnitOfWork;
using PhoneService.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Services
{
    public class RepairService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly NullCheckMethod _nullCheckMethod;

        public RepairService(IUnitOfWork unitOfWork, NullCheckMethod nullCheckMethod)
        {
            _unitOfWork = unitOfWork;
            _nullCheckMethod = nullCheckMethod;
        }
    }
}
