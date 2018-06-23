using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.DTO
{
    public class WeeklyHourCalculationResult
    {
        public IEnumerable<DateTime> WorkedDays { get; set; }
        public double TotalWorkedHours { get; set; }
        public double WeekOvertime { get; set; }
    }
}
