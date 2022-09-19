using ConsoleApp.Employees;

namespace ConsoleApp.Infrastructure.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetByFirstItem();
        void Create(Employee employee);
    }
}
