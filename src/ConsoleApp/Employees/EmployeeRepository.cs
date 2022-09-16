using ConsoleApp.Data;
using ConsoleApp.Infrastructure.Repository;

namespace ConsoleApp.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == employeeId);
        }
    }
}
