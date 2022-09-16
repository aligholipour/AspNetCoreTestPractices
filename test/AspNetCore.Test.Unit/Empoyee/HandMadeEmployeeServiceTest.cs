using AspNetCore.Test.Unit.Empoyee.TestDoubles;
using ConsoleApp.Employee;
using FluentAssertions;

namespace AspNetCore.Test.Unit.Empoyee
{
    public class HandMadeEmployeeServiceTest
    {
        [Fact]
        public void save_employee_on_registration()
        {
            var mockRepository = new HandMadeMockEmployeeRepository();
            var employeeService = new EmployeeService(mockRepository);
            var expected = new Employee() { Firstname = "john", Lastname = "doe" };

            employeeService.RegisterEmployee("john", "doe");

            mockRepository.GetCall(nameof(IEmployeeRepository.Create)).CallTimes.Should().Be(1);
            mockRepository.GetCall(nameof(IEmployeeRepository.Create)).PassedArgument.Should().BeEquivalentTo(expected);
        }
    }
}
