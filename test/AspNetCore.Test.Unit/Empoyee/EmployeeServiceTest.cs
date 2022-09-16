using ConsoleApp.Employee;
using NSubstitute;

namespace AspNetCore.Test.Unit.Empoyee
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void save_employee_on_registration()
        {
            var mockRepository = Substitute.For<IEmployeeRepository>();
            var employeeService = new EmployeeService(mockRepository);
            var expected = new Employee() { Firstname = "john", Lastname = "doe" };

            employeeService.RegisterEmployee("john", "doe");

            mockRepository.Received(1).Create(Arg.Is<Employee>(e => e.Firstname == "john" && e.Lastname == "doe"));

        }
    }
}
