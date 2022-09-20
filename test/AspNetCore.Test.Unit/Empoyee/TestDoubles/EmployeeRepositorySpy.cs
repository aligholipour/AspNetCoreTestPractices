using ConsoleApp.Employees;
using ConsoleApp.Infrastructure.Repository;

namespace AspNetCore.Test.Unit.Empoyee.TestDoubles
{
    public class EmployeeRepositorySpy : IEmployeeRepository
    {
        private Employee Employee;
        private int CallNumbers;

        public void Create(Employee employee)
        {
            this.Employee = employee;
            CallNumbers++;
        }

        public Employee GetByFirstItem() => this.Employee;

        public int GetNumberOfCreateEmployees => CallNumbers;
    }
}
