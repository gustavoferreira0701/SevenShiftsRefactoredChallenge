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
        public double TotalOvertimeHours { get; set; }
        public Wage WageData { get; set; }
    }
}
