using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Tests
{
    [TestClass]
    public class EmployeeWageCalculatorTest
    {
        private LabourSettings labourSettings;

        [TestMethod]
        public void ShouldCalculateDailyWage()
        {
            //GIVEN
            double workedHours = 8d;
            double overtimeHours = 0.57d;

            decimal employeeHourSalary = 10;

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WageHourCalculator();
            var result = calculator.CalculateDailyWage(workedHours, overtimeHours, employeeHourSalary, labourSettings);
            //THEN
            Assert.IsNotNull(result);
            Assert.AreEqual(8.55m, result.OvertimeWage);
            Assert.AreEqual(80m, result.RegularWage);
        }

        [TestMethod]
        public void ShouldCalculateWeeklyyWage()
        {
        }
    }
}
