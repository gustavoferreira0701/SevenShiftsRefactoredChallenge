using SevenShifts.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SevenShifts.Application
{
    public class Employee : IEmployee
    {
        public Task<IEnumerable<Domain.Entities.Employee>> GetAllEmployeeData()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Employee> GetEmployeeData(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
