using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System.Collections.Generic;

namespace SevenShifts.Domain.Contracts
{
    public interface IWorkedHourCalculator
    {
        IEnumerable<WorkedWeekCalculationResult> CalculateWorkedWeek(List<TimePunch> punches, LabourSettings labourSettings);
        WorkedHourCalculationResult CalculateWorkedDay(IEnumerable<TimePunch> dailyPunches, LabourSettings labourSettings);
    }
}
