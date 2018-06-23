using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class AutoBreakRule
    {
        public long BreakLength { get; set; }

        public long Threshold { get; set; }
    }
}
