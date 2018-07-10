using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class Wage
    {
        public decimal BaseWage { get; set; }
        public decimal ExtraWage { get; set; }
        public decimal Total => BaseWage + ExtraWage;
    }
}
