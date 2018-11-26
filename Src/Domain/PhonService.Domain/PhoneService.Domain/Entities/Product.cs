using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Producer  { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }

        public ICollection<SaparePart> SaparePart { get; set; }

    }
}
