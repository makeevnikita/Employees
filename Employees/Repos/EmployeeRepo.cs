using Employees.Context;
using Employees.Model;
using System.Data.Entity;
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
        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeesContext.Employees;
        }
        public void CreateEmployee(string surname, string name, string patronymic, Post post)
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
        public void LoadLocal()
        {
            _employeesContext.Posts.Load();
        }
        //public IEnumerable GetAllEmployees()
        //{
        //    return (from employee in _employeesContext.Employees
        //            join post in _employeesContext.Posts on employee.Post.Id equals post.Id
        //            select new { Surname = employee.Surname, Name = employee.Name, Patronymic = employee.Patronymic });
        //    return _employeesContext.Employees.Join(_employeesContext.Posts,
        //        e => e.Post.Id,
        //        p => p.Id,
        //        (e, p) => new { Surname = e.Surname, Name = e.Name, Patronymic = e.Patronymic });
        //}
    }
}
