using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Tests.Mocks
{
    public class TimePunchesMock
    {
        public static TimePunch[] GetThreeWeeksFromEmployee()
        {
            return new TimePunch[] {
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-04 09:11:00"),
                    ClockedOut = DateTime.Parse("2018-07-04 18:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-05 09:01:00"),
                    ClockedOut = DateTime.Parse("2018-07-05 18:01:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-09 08:00:00"),
                    ClockedOut = DateTime.Parse("2018-07-09 16:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-10 11:11:00"),
                    ClockedOut = DateTime.Parse("2018-07-10 19:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-11 12:11:00"),
                    ClockedOut = DateTime.Parse("2018-07-11 21:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-12 21:11:00"),
                    ClockedOut = DateTime.Parse("2018-07-13 05:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-13 18:00:00"),
                    ClockedOut = DateTime.Parse("2018-07-13 23:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                },
                new TimePunch
                {
                    ClockedIn = DateTime.Parse("2018-07-14 12:11:00"),
                    ClockedOut = DateTime.Parse("2018-07-14 19:45:00"),
                    Created = DateTime.Parse("2018-07-11 21:11:38"),
                    HourlyWage = 07,
                    Id = 4046830,
                    LocationId = 4046830,
                    Modified = DateTime.Parse("2018-07-12 05:45:49"),
                    UserId = 517135
                }
            };
        }
    }
}
