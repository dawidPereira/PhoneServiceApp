using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneService.Domain.Repository
{
    public interface IProductSaparePartRepository
    {
        void AddProductSaparePart(ProductSaparePart productSapare);
        void RemoveProductSaparePart(ProductSaparePart productSapare);
    }
}
