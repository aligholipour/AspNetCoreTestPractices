using ConsoleApp.Employees;
using ConsoleApp.Infrastructure.Repository;
using FluentAssertions;

namespace AspNetCore.Test.Unit.Empoyee
{
    public class EmplyoeeServiceTestSelfShunt : IEmployeeRepository
    {
        private Employee CreateEmployee;
        private int NumberOfCreateEmployee;

        [Fact]
        public void save_employee_on_registration_with_spy()
        {
            var service = new EmployeeService(this);

            service.RegisterEmployee(new EmployeeDto { Id = 1, Firstname = "john", Lastname = "doe" });

            NumberOfCreateEmployee.Should().Be(1);

            CreateEmployee.Id.Should().Be(1);
            CreateEmployee.Firstname.Should().Be("john");
            CreateEmployee.Lastname.Should().Be("doe");
        }

        public void Create(Employee employee)
        {
            this.CreateEmployee = employee;
            NumberOfCreateEmployee++;
        }

        public Employee GetByFirstItem()
        {
            return this.CreateEmployee;
        }
    }
}
