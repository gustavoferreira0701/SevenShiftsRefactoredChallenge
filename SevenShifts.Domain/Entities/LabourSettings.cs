using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class LabourSettings
    {        
        public bool AutoBreak { get; set; }
                
        public AutoBreakRule[] AutoBreakRules { get; set; }
                
        public double DailyOvertimeMultiplier { get; set; }
                
        public long DailyOvertimeThreshold { get; set; }
                
        public bool Overtime { get; set; }
                
        public double WeeklyOvertimeMultiplier { get; set; }
                
        public long WeeklyOvertimeThreshold { get; set; }
    }
}
