using ConsoleApp.Infrastructure.Repository;

namespace ConsoleApp.Employees
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void RegisterEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee(employeeDto.Id, employeeDto.Firstname, employeeDto.Lastname);

            _employeeRepository.Create(employee);
        }
    }
}
