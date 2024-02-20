using EmployeeDepartmentDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentDemo.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
