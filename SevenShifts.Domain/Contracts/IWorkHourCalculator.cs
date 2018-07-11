using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System.Collections.Generic;

namespace SevenShifts.Domain.Contracts
{
    public interface IWorkedHourCalculator
    {
        IEnumerable<WorkedWeekCalculationResult> CalculateWorkedWeek(IEnumerable<TimePunch> punches, LabourSettings labourSettings, User userData);
        WorkedHourCalculationResult CalculateWorkedDay(IEnumerable<TimePunch> dailyPunches, LabourSettings labourSettings);
    }
}
