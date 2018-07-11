using SevenShifts.Domain.Entities;
using SevenShifts.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.DTO
{
    public class WorkedHourCalculationResult
    {   
        public EWorkHourStatus Status { get; set; }
        public DateTime WorkedDate { get; set; }
        public IEnumerable<TimePunch> Punches { get; set; }
        public double TotalRegularHours { get; set; }
        public double TotalOvertimeHours { get; set; }
        public Wage WageData { get; set; }
    }
}
