using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System.Collections.Generic;

namespace SevenShifts.Domain.Contracts
{
    public interface IWorkedHourCalculator
    {
        WorkedHourCalculationResult CalculateWorkedDay(IEnumerable<TimePunch> dailyPunches, LabourSettings labourSettings);
    }
}
