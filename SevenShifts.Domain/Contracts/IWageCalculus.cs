using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Contracts
{
    interface IWageCalculus
    {
        WageCalculatorResult CalculateDailyWage(double totalRegularWorkedHours, double totalOverTimeWorkedHours, decimal employeeSalary, LabourSettings labourSettings);
        WageCalculatorResult CalculateWeeklyWage();
    }
}
