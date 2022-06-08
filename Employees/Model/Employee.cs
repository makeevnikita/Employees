namespace Employees.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public bool IsSupervisor { get; set; }
        public Subdivision Subdivision { get; set; }
        public Post Post { get; set; }
    }
}
