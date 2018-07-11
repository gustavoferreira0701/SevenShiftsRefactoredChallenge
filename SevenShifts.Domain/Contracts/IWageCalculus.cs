using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Contracts
{
    public interface IWageCalculator
    {
        WageCalculationResult CalculateWage(double totalRegularWorkedHours,
                                           double totalOverTimeWorkedHours,
                                           decimal employeeSalary,
                                           decimal overtimeMultiplier);
    }
}
