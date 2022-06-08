using System.Collections.Generic;

namespace Employees.Model
{
    public class Subdivision
    {
        public int Id { get; set; }
        public string SubdivisionName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
