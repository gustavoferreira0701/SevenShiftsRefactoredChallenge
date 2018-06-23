using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Contracts
{
    public interface IWorkHourCalculator
    {
        WorkHourCalculationResult CalculateWorkedHour(TimePunch timePunch);
        IEnumerable<WorkHourCalculationResult> CalculateDailyWorkedHour(IEnumerable<TimePunch> timePunchs);
        WeeklyHourCalculationResult CalculateWeeklyOverTime(IEnumerable<TimePunch> timePunchs);
    }
}
