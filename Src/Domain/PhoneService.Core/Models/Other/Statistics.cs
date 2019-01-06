using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneService.Core.Models.Other
{
    public class Statistics
    {
        public int New { get; set; }
        public int Priced { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
        public int Rejected { get; set; }
    }
}
