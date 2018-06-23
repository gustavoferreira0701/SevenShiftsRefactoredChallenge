using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Domain.Contracts
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Domain.Entities.Location>> GetLocations();
        Task<Domain.Entities.Location> GetLocationById(long id);
    }
}
