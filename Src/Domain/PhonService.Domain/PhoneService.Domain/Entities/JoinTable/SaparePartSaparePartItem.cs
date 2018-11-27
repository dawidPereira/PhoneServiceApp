using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Domain
{
    public class SaparePartSaparePartItem
    {
        public int SaparePartItemId { get; set; }
        public SaparePartItem SaparePartItem { get; set; }
        public int SaparePartId { get; set; }
        public SaparePart SaparePart { get; set; }
    }
}
