using ConsoleApp.Employees;

namespace ConsoleApp.Infrastructure.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetById(int employeeId);
        void Create(Employee employee);
    }
}
