using AspNetCore.Test.Unit.Empoyee.TestDoubles;
using ConsoleApp.Employees;
using ConsoleApp.Infrastructure.Repository;
using FluentAssertions;
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
            var expected = new Employee(1, "john", "doe");

            employeeService.RegisterEmployee(new EmployeeDto { Id= 1, Firstname = "john", Lastname = "doe" });

            mockRepository.Received(1).Create(Arg.Is<Employee>(e => e.Firstname == "john" && e.Lastname == "doe"));
        }

        [Fact]
        public void save_employee_on_registration_with_spy()
        {
            var repository = new EmployeeRepositorySpy();
            var service = new EmployeeService(repository);

            service.RegisterEmployee(new EmployeeDto { Id = 1, Firstname = "john", Lastname = "doe" });

            repository.GetNumberOfCreateEmployees.Should().Be(1);
            repository.GetByFirstItem().Id.Should().Be(1);
            repository.GetByFirstItem().Firstname.Should().Be("john");
            repository.GetByFirstItem().Lastname.Should().Be("doe");
        }
    }
}
