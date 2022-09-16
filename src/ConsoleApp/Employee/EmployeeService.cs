namespace ConsoleApp.Employee
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void RegisterEmployee(string firstName, string lastName)
        {
            var employee = new Employee
            {
                Firstname = firstName,
                Lastname = lastName
            };

            _employeeRepository.Create(employee);
        }
    }
}
