using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.DTO;
using SevenShifts.Domain.Enum;
using SevenShifts.Helpers.Extensions;
using SevenShifts.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenShifts.Domain.Entities
{
    public class WorkedHourCalculator : IWorkedHourCalculator
    {
        public IEnumerable<WorkedWeekCalculationResult> CalculateWorkedWeek(List<TimePunch> punches, LabourSettings labourSettings)
        {
            var dailyResults = new List<WorkedHourCalculationResult>();

            foreach (var punch in punches.GroupBy(x => x.ClockedIn))
            {
                dailyResults.Add(CalculateWorkedDay(punch.ToList(), labourSettings));
            }

            var weekResults = new List<WorkedWeekCalculationResult>();

            foreach (var week in dailyResults.GroupBy(x => DateHelper.GetWeekNumber(x.WorkedDate)))
            {
                weekResults.Add(new WorkedWeekCalculationResult
                {
                    TotalRegularHours = week.Sum(x => x.TotalRegularHours),
                    TotalOvertimeHours = (week.Sum(x => x.TotalRegularHours + x.TotalOvertimeHours) - labourSettings.WeeklyOvertimeThreshold),
                    WorkedDays = week
                });
            }

            return weekResults;
        }

        public WorkedHourCalculationResult CalculateWorkedDay(IEnumerable<TimePunch> dailyPunches, LabourSettings labourSettings)
        {
            var validationResult = Validate(dailyPunches.ToArray());

            if (validationResult.Status != EWorkHourStatus.ValidWorkDay)
                return validationResult;

            var calculationResult = validationResult;

            dailyPunches.OrderBy(t => t.ClockedIn);

            var workedMinutes = 0.0d;

            foreach (var timePunch in dailyPunches)
            {
                workedMinutes += (timePunch.ClockedOut - timePunch.ClockedIn).TotalMinutes;
            }

            calculationResult.WorkedDate = dailyPunches.First().ClockedIn;

            calculationResult.TotalRegularHours = workedMinutes > labourSettings.DailyOvertimeThreshold ? ((double)(labourSettings.DailyOvertimeThreshold / 60)).LimitToTimeFormat() : (double)(workedMinutes / 60).LimitToTimeFormat();
            calculationResult.TotalOvertimeHours = workedMinutes > labourSettings.DailyOvertimeThreshold ? ((workedMinutes - labourSettings.DailyOvertimeThreshold) / 60).LimitToTimeFormat() : 0;

            return calculationResult;
        }

        private WorkedHourCalculationResult Validate(TimePunch[] dailyPunches)
        {
            if (dailyPunches == null || !dailyPunches.Any())
            {
                return new WorkedHourCalculationResult
                {
                    Status = EWorkHourStatus.Undefined
                };
            }

            dailyPunches.OrderBy(t => t.ClockedIn);

            var firstPunchOfDay = dailyPunches.First().ClockedIn;

            var validationResult = new WorkedHourCalculationResult();

            for (int i = 0; i < dailyPunches.Count(); i++)
            {
                var timePunch = dailyPunches[i];

                if ((i != 0 && timePunch.ClockedIn < dailyPunches[i - 1].ClockedOut))
                {
                    return new WorkedHourCalculationResult()
                    {
                        Status = EWorkHourStatus.TimePunchesInvalid,
                        Punches = dailyPunches,
                        WorkedDate = firstPunchOfDay
                    };
                }

                if (timePunch.ClockedIn.IsNullOrDefault() || timePunch.ClockedOut.IsNullOrDefault())
                {
                    return new WorkedHourCalculationResult()
                    {
                        Status = EWorkHourStatus.MissingClockEntries,
                        Punches = dailyPunches,
                        WorkedDate = firstPunchOfDay
                    };
                }

            }

            validationResult.Status = EWorkHourStatus.ValidWorkDay;

            return validationResult;
        }
    }
}
