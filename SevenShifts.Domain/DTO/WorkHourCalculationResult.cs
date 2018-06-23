using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.DTO
{
    public class WorkHourCalculationResult
    {
        public DateTime WorkedDate { get; set; }
        public double TotalWorkedHours { get; set; }
        public double TotalOvertime { get; set; }
    }
}
