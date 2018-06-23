﻿using SevenShifts.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class Employee
    {
        public User RelatedUser { get; set; }

        public Location RelatedLocation { get; set; }

        public IEnumerable<TimePunch> RelatedPunches { get; set; }

        public WeeklyHourCalculationResult TotalWeeklyWorkedHours { get; set; }        
    }
}
