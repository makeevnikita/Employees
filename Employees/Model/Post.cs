using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Model
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string PostName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
