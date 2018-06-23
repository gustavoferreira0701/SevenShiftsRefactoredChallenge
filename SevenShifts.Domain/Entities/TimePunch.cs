using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class TimePunch
    {
        public DateTime ClockedIn { get; set; }

        public DateTime ClockedOut { get; set; }

        public DateTime Created { get; set; }

        public double HourlyWage { get; set; }

        public long Id { get; set; }

        public long LocationId { get; set; }

        public DateTime Modified { get; set; }

        public long UserId { get; set; }
    }
}
