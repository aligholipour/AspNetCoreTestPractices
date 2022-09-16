using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employees.Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=AspNetCoreTestPracticeDB;Integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
