﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Application.Contracts
{
    public interface IEmployee
    {
        Task<IEnumerable<Domain.Entities.Employee>> GetAllEmployeeData();
        Task<Domain.Entities.Employee> GetEmployeeData(int userId);
    }
}
