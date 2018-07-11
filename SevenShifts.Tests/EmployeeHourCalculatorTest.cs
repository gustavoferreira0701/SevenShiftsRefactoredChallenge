using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SevenShifts.Domain.Entities;
using SevenShifts.Repository.Repositories;
using SevenShifts.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenShifts.Tests
{
    [TestClass]
    public class EmployeeHourCalculatorTest
    {

        private List<TimePunch> punches;
        private LabourSettings labourSettings;
        private User user;


        [TestInitialize]
        public void Initialize()
        {
            user = new User { HourlyWage = 10 };
        }

        #region Daily Calculation
        [TestMethod]
        public void ShouldValidateOverTimeWithSingleTimePunch()
        {
            //GIVEN
            punches = new List<TimePunch>
            {
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 21:11:00"),
                    ClockedOut = DateTime.Parse("2017-10-12 05:45:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                }
            };

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedDay(punches, labourSettings);

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.AreEqual(8.0d, calculationResult.TotalRegularHours);
            Assert.AreEqual(0.57d, calculationResult.TotalOvertimeHours);
        }

        [TestMethod]
        public void ShouldValidateOverTimeWithMultipleTimePunches()
        {
            //GIVEN
            punches = new List<TimePunch>
            {
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 10:00:00"),
                    ClockedOut = DateTime.Parse("2017-10-11 13:00:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                },

                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 21:00:00"),
                    ClockedOut = DateTime.Parse("2017-10-12 03:00:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                }
            };

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedDay(punches.ToArray(), labourSettings);

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.IsTrue(calculationResult.Status == Domain.Enum.EWorkHourStatus.ValidWorkDay);
            Assert.AreEqual(8.0d, calculationResult.TotalRegularHours);
            Assert.AreEqual(1.0d, calculationResult.TotalOvertimeHours);
        }

        [TestMethod]
        public void ShouldValidateAnDayWithoutOvertime()
        {
            //GIVEN
            punches = new List<TimePunch>
            {
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 21:11:00"),
                    ClockedOut = DateTime.Parse("2017-10-12 05:11:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                }
            };

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedDay(punches, labourSettings);

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.AreEqual(8.0d, calculationResult.TotalRegularHours);
            Assert.AreEqual(0, calculationResult.TotalOvertimeHours);
        }

        [TestMethod]
        public void ShouldIdentifyAnInvalidWorkDate()
        {
            //GIVEN
            punches = new List<TimePunch>
            {
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 21:11:00"),
                    ClockedOut = DateTime.Parse("2017-10-12 05:11:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 23:20:00"),
                    ClockedOut = DateTime.Parse("2017-10-12 06:11:00"),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                }
            };

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedDay(punches, labourSettings);

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.IsTrue(calculationResult.Status == Domain.Enum.EWorkHourStatus.TimePunchesInvalid);
        }

        [TestMethod]
        public void ShouldIdentifyAWorkDateWithMissingClockOut()
        {
            //GIVEN
            punches = new List<TimePunch>
            {
                new TimePunch{
                    ClockedIn = DateTime.Parse("2017-10-11 21:11:00"),
                    ClockedOut = default(DateTime),
                    Created = DateTime.Parse("2017-10-11 21:11:38"),
                    HourlyWage = 10,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2017-10-12 05:45:49"),
                    UserId = 517135
                }
            };

            labourSettings = new LabourSettings
            {
                DailyOvertimeMultiplier = 1.5,
                DailyOvertimeThreshold = 480,
                Overtime = true,
                WeeklyOvertimeMultiplier = 2,
                WeeklyOvertimeThreshold = 2400
            };

            //WHEN
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedDay(punches, labourSettings);

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.IsTrue(calculationResult.Status == Domain.Enum.EWorkHourStatus.MissingClockEntries);
        }
        #endregion

        #region Weekly Calculation

        [TestMethod]
        public void ShoudValidateWeeklyTimePunchWithoutWeekOvertime()
        {
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
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedWeek(punches, labourSettings, user).ToArray();

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.AreEqual(2, calculationResult.Count());
            Assert.IsTrue(calculationResult[0].TotalWeekOverTime <= labourSettings.WeeklyOvertimeThreshold);

        }

        [TestMethod]
        public void ShoudValidateWeeklyTimePunchWithWeekOvertime()
        {
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
            var calculator = new WorkedHourCalculator(new BasicWageCalculator());
            var calculationResult = calculator.CalculateWorkedWeek(punches, labourSettings, user).ToArray();

            //THEN
            Assert.IsNotNull(calculationResult);
            Assert.AreEqual(2, calculationResult.Count());
            Assert.IsTrue(calculationResult[1].TotalWeekOverTime > 0);

        }

        #endregion  

    }
}
