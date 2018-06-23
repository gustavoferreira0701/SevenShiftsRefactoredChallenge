using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SevenShifts.Domain.Entities;
using SevenShifts.Repository.Repositories;

namespace SevenShifts.Tests
{
    [TestClass]
    public class EmployeeHourCalculatorTest
    {
        [TestMethod]
        public void ShouldValidateOverTimeOnSingleDay()
        {
            var timepunchRepository = new Mock<TimePunchRepository>().sho;
            var userRepository = new Mock<UserRepository>();
            var locationRepository = new Mock<LocationRepository>();
            var workHourCalculator = new Mock<WorkHourCalculator>();

            var employeeApp = new SevenShifts.Application.Employee(timepunchRepository.Object,
                                                                   userRepository.Object,
                                                                   locationRepository.Object, workHourCalculator.Object);

            var result = employeeApp.GetEmployeeData();
        }
    }
}
