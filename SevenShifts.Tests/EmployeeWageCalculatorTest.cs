using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SevenShifts.Domain.Entities;
using SevenShifts.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SevenShifts.Tests
{
    [TestClass]
    public class EmployeeWageCalculatorTest
    {
        private List<TimePunch> punches;
        private LabourSettings labourSettings;

        private User user;


        [TestInitialize]
        public void Initialize()
        {
            user = new User { HourlyWage = 10 };
        }

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
            var calculator = new BasicWageCalculator();
            var result = calculator.CalculateWage(workedHours, overtimeHours, employeeHourSalary, (decimal)labourSettings.DailyOvertimeMultiplier);
            //THEN
            Assert.IsNotNull(result);
            Assert.AreEqual(8.55m, result.OvertimeWage);
            Assert.AreEqual(80m, result.RegularWage);
        }

        [TestMethod]
        public void ShouldCalculateWeeklyWageWithoutOvertime()
        {
            decimal employeeHourSalary = 10;

            //GIVEN
            punches = TimePunchesMock.GetThreeWeeksFromEmployee().ToList();

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var hourCalculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResults = hourCalculator.CalculateWorkedWeek(punches, labourSettings, user).ToArray();
            var wageCalculator = new BasicWageCalculator();
            var weeklyCalculatedWage = wageCalculator.CalculateWage(calculationResults[0].TotalRegularHours, calculationResults[0].TotalWeekOverTime, employeeHourSalary, (decimal)labourSettings.WeeklyOvertimeMultiplier);
            var dailyCalculatedWage = wageCalculator.CalculateWage(calculationResults[0].TotalRegularHours, calculationResults[0].TotalDailyOverTime, employeeHourSalary, (decimal)labourSettings.DailyOvertimeMultiplier);

            //THEN

            Assert.IsNotNull(weeklyCalculatedWage);
            Assert.AreEqual(0.0m, weeklyCalculatedWage.OvertimeWage);
            Assert.AreEqual(38.55m, dailyCalculatedWage.OvertimeWage);
            Assert.AreEqual(160m, weeklyCalculatedWage.RegularWage);
        }
    }
}
