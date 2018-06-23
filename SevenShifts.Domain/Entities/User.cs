using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Entities
{
    public class User
    {
        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public long HourlyWage { get; set; }

        public long Id { get; set; }

        public string LastName { get; set; }

        public long LocationId { get; set; }

        public DateTime Modified { get; set; }

        public string Photo { get; set; }

        public long UserType { get; set; }


    }
}
