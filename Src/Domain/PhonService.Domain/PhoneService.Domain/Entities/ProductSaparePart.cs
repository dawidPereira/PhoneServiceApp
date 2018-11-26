using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class ProductSaparePart
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SaparePartId { get; set; }
        public SaparePart SaparePart { get; set; }
    }
}
