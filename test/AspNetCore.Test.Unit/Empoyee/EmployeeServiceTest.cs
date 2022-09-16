using AspNetCore.Test.Unit.Empoyee.TestDoubles;
using ConsoleApp.Employee;
using FluentAssertions;

namespace AspNetCore.Test.Unit.Empoyee
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void save_employee_on_registration()
        {
            var mockRespository = new HandMadeMockEmployeeRepository();
            var employeeService = new EmployeeService(mockRespository);
            var expected = new Employee() { Firstname = "john", Lastname = "doe" };

            employeeService.RegisterEmployee("john", "doe");

            mockRespository.GetCall(nameof(IEmployeeRepository.Create)).CallTimes.Should().Be(1);
            mockRespository.GetCall(nameof(IEmployeeRepository.Create)).PassedArgument.Should().BeEquivalentTo(expected);
        }
    }
}
