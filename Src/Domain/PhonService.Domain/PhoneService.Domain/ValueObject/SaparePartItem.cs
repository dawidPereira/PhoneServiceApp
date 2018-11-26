using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class SaparePartItem
    {
        public SaparePart SeparePart { get; set; }
        public int Quantity { get; set; }

        public ICollection<SaparePart> SapareParts { get; set; }
    }
}
