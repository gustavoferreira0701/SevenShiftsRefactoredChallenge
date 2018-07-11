using SevenShifts.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class WorkedWeekCalculationResult
    {
        public IEnumerable<WorkedHourCalculationResult> WorkedDays { get; set; }
        public double TotalRegularHours { get; set; }
        public double TotalWeekOverTime { get; set; }
        public double TotalDailyOverTime { get; set; }
        public WageCalculationResult WageData { get; set; }
        public IEnumerable<WorkedHourCalculationResult> NotValidWorkDays { get; set; }
    }
}
