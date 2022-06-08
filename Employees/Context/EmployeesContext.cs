using Employees.Model;
using System.Data.Entity;

namespace Employees.Context
{
    public class EmployeesContext : System.Data.Entity.DbContext
    {
        public EmployeesContext() : base("EmployeesConnection") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
    }
}
