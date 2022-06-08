using Employees.Context;
using Employees.Model;
using System.Linq;

namespace Employees.Repos
{
    internal class PostRepo
    {
        private EmployeesContext _employeesContext;
        public PostRepo()
        {
            _employeesContext = new EmployeesContext();
        }
        public IQueryable<Post> GetAllPosts()
        {
            return _employeesContext.Posts;
        }
        public Post GetPostById(int id)
        {
            return _employeesContext.Posts.Where(w => w.Id == id).FirstOrDefault();
        }

    }
}
