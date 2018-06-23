using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Domain.Contracts
{
    public interface ITimePunchRepository
    {
        Task<IEnumerable<Domain.Entities.TimePunch>> GetTimePunches();
        Task<IEnumerable<Domain.Entities.TimePunch>> GetTimePunchesByUserId(long id);
    }
}
