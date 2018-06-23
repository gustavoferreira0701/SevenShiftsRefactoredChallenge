using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class WorkHourCalculator : IWorkHourCalculator
    {
        private const int WEEK_SIZE = 7;
        private const int DAILY_WORKHOUR_LIMIT = 8;
        private const int WEEK_WORKHOUR_LIMIT = 40;

        public WorkHourCalculationResult CalculateWorkedHour(TimePunch timePunch)
        {
            var result = timePunch.ClockedOut.Subtract(timePunch.ClockedIn);

            return new WorkHourCalculationResult
            {
                WorkedDate = timePunch.ClockedIn.Date,
                TotalWorkedHours = result.TotalHours,
                TotalOvertime = (result.TotalHours - DAILY_WORKHOUR_LIMIT) > 0 ? (result.TotalHours - DAILY_WORKHOUR_LIMIT) : 0
            };
        }

        public IEnumerable<WorkHourCalculationResult> CalculateDailyWorkedHour(IEnumerable<TimePunch> timePunchs)
        {
            List<WorkHourCalculationResult> result = new List<WorkHourCalculationResult>();

            var groupedResult = (from timePunch in timePunchs
                                 group timePunch by timePunch.ClockedIn.Date into timePunchGroup
                                 orderby timePunchGroup.Key ascending
                                 select timePunchGroup);

            foreach (var timePunch in groupedResult)
            {
                var workCalculation = new WorkHourCalculationResult { WorkedDate = timePunch.Key };
                foreach (var item in timePunch)
                {
                    var iterationResult = CalculateWorkedHour(item);
                    workCalculation.TotalWorkedHours += iterationResult.TotalWorkedHours;
                    workCalculation.TotalOvertime += iterationResult.TotalOvertime;
                }
                result.Add(workCalculation);
            }

            return result.ToList();
        }

        public WeeklyHourCalculationResult CalculateWeeklyOverTime(IEnumerable<TimePunch> timePunchs)
        {
            var workHourCalculationResult = CalculateDailyWorkedHour(timePunchs);

            var amountOfWorkedHourOnLastSevenDays = workHourCalculationResult.OrderByDescending(x => x.WorkedDate)
                                                         .Take(WEEK_SIZE);

            var totalWorkedHours = amountOfWorkedHourOnLastSevenDays.Sum(x => x.TotalWorkedHours);

            return new WeeklyHourCalculationResult
            {
                WorkedDays = amountOfWorkedHourOnLastSevenDays.Select(x => x.WorkedDate),
                TotalWorkedHours = totalWorkedHours,
                WeekOvertime = (totalWorkedHours - WEEK_WORKHOUR_LIMIT) > 0 ? (totalWorkedHours - WEEK_WORKHOUR_LIMIT) : amountOfWorkedHourOnLastSevenDays.Sum(x => x.TotalOvertime)
            };
        }

    }
}
