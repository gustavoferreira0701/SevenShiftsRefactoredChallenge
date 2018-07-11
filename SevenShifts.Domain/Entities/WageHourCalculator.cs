using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class BasicWageCalculator : IWageCalculator
    {        
        public WageCalculationResult CalculateWage(double totalRegularWorkedHours, 
                                                  double totalOverTimeWorkedHours, 
                                                  decimal employeeSalary, 
                                                  decimal overtimeMultiplier)
        {
            return new WageCalculationResult
            {
                RegularWage = Math.Round(((decimal)totalRegularWorkedHours * employeeSalary), 2),
                OvertimeWage = Math.Round((decimal)totalOverTimeWorkedHours * (employeeSalary * overtimeMultiplier), 2)
            };
        }
    }
}
