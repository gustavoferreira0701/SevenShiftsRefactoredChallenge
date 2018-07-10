using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class WageHourCalculator : IWageCalculus
    {

        //double totalWorkedHours, decimal employeeSalary, LabourSettings labourSettings
        public WageCalculatorResult CalculateDailyWage(double totalRegularWorkedHours, double totalOverTimeWorkedHours, decimal employeeSalary, LabourSettings labourSettings)
        {
            return new WageCalculatorResult
            {
                RegularWage = Math.Round(((decimal)totalRegularWorkedHours * employeeSalary), 2),
                OvertimeWage = Math.Round(((decimal)totalOverTimeWorkedHours * (employeeSalary * (decimal)labourSettings.DailyOvertimeMultiplier)), 2)
            };
        }

        public WageCalculatorResult CalculateWeeklyWage()
        {
            throw new NotImplementedException();
        }
    }
}
