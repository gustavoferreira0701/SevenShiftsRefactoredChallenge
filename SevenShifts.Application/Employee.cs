using SevenShifts.Application.Contracts;
using SevenShifts.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenShifts.Application
{
    public class Employee : IEmployee
    {
        private ILocationRepository _locationRepository;
        private IUserRepository _userRepository;
        private ITimePunchRepository _timePunchRepository;
        private IWorkedHourCalculator _workedHourCalculator;

        public Employee(ILocationRepository locationRepository,
                         IUserRepository userRepository,
                         ITimePunchRepository timePunchRepository,
                         IWorkedHourCalculator workedHourCalculator)
        {
            _timePunchRepository = timePunchRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _workedHourCalculator = workedHourCalculator;            
        }

        public Task<IEnumerable<Domain.Entities.Employee>> GetAllEmployeeData()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Employee> GetEmployeeData(int userId)
        {
            var user = await _userRepository.GetByUserId(userId);

            if (user == null)
                throw new Exception("No user information found.");

            var location = await _locationRepository.GetLocationById(user.LocationId);

            if (location == null)
                throw new Exception("No location information found.");

            var punches = await _timePunchRepository.GetTimePunchesByUserId(userId);

            if (punches == null)
                throw new Exception($"No time punch found for user {userId}");


            var workHourCalculationResult = _workedHourCalculator.CalculateWorkedWeek(punches, location.LabourSettings, user);
            
            var employeeData = new Domain.Entities.Employee
            {
                RelatedLocation = location, 
                RelatedUser = user, 
                WorkReport = workHourCalculationResult
            };

            return employeeData;

        }
    }
}
