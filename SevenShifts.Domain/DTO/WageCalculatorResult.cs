using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.DTO
{
    public class WageCalculatorResult
    {
        public decimal RegularWage { get; set; }
        public decimal OvertimeWage { get; set; }
    }
}
