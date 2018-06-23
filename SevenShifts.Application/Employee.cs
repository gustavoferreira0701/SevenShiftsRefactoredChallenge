using SevenShifts.Application.Contracts;
using SevenShifts.Domain.Contracts;
using SevenShifts.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenShifts.Application
{
    public class Employee : IEmployee
    {
        private readonly ITimePunchRepository _timePunchRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IWorkHourCalculator _workHourCalculator;

        public Employee(ITimePunchRepository timePunchRepository,
                    IUserRepository userRepository,
                    ILocationRepository locationRepository,
                    IWorkHourCalculator workHourCalculator)
        {
            _timePunchRepository = timePunchRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
            _workHourCalculator = workHourCalculator;
        }

        public async Task<IEnumerable<Domain.Entities.Employee>> GetEmployeeData()
        {
            var users = await _userRepository.GetUsers();
            var locations = await _locationRepository.GetLocations();
            var timePunches = await _timePunchRepository.GetTimePunches();
            var employees = new List<Domain.Entities.Employee>();
            foreach (var user in users)
            {
                employees.Add(new Domain.Entities.Employee
                {
                    RelatedUser = user,
                    RelatedLocation = locations.FirstOrDefault(x => x.Id == user.Id),
                    RelatedPunches = timePunches.Where(q => q.UserId == user.Id),
                    TotalWeeklyWorkedHours = _workHourCalculator.CalculateWeeklyOverTime(timePunches.Where(q => q.UserId == user.Id))
                });
            }

            return employees;
        }

        public async Task<Domain.Entities.Employee> GetEmployeeData(int id)
        {
            var user = await _userRepository.GetByUserId(id);
            var locations = _locationRepository.GetLocationById(user.LocationId);
            var timePunches = _timePunchRepository.GetTimePunchesByUserId(user.Id);

            Task.WaitAll(locations, timePunches);

            var employees = new List<Domain.Entities.Employee>();

            return new Domain.Entities.Employee
            {
                RelatedUser = user,
                RelatedLocation = locations.Result,
                RelatedPunches = timePunches.Result,
                TotalWeeklyWorkedHours = _workHourCalculator.CalculateWeeklyOverTime(timePunches.Result)
            };
        }
    }
}
