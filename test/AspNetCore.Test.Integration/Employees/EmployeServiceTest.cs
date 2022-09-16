using ConsoleApp.Data;
using ConsoleApp.Employees;
using FluentAssertions;

namespace AspNetCore.Test.Integration.Employees
{
    public class EmployeServiceTest : PersistTest<AppDbContext>
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

            var expected = new Employee(1, "john", "doe");

            service.RegisterEmployee(employeeDto);

            var actual = repository.GetById(1);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
