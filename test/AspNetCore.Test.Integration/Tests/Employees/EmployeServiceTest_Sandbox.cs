using AspNetCore.Test.Integration.Utils;
using ConsoleApp.Employees;
using FluentAssertions;

namespace AspNetCore.Test.Integration.Tests.Employees
{
    public class EmployeServiceTest_Sandbox : SandboxPersistTest
    {
        [Fact]
        public void saves_a_employee_into_database()
        {
            var repository = new EmployeeRepository(DbContext);
            var service = new EmployeeService(repository);
            var employeeDto = new EmployeeDto
            {
                Firstname = "john",
                Lastname = "doe"
            };

            service.RegisterEmployee(employeeDto);

            var actual = repository.GetByFirstItem();

            var expected = new Employee(actual.Id, "john", "doe");

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
