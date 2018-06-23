using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Domain.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<Domain.Entities.User>> GetUsers();
        Task<Domain.Entities.User> GetByUserId(int id);
    }
}
