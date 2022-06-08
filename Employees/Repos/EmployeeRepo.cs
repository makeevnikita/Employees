using Employees.Context;
using Employees.Model;
using System.Linq;

namespace Employees.Repos
{
    internal class EmployeeRepo
    {
        private EmployeesContext _employeesContext;
        public EmployeeRepo()
        {
            _employeesContext = new EmployeesContext();
        }
        internal IQueryable<Employee> GetAllEmployees()
        {
            return _employeesContext.Employees;
        }
        internal void CreateEmployee(string surname, string name, string patronymic, Post post)
        {
            Employee employee = new Employee
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Post = post
            };
            _employeesContext.Employees.Add(employee);
            _employeesContext.SaveChanges();
        }
    }
}
