namespace Employees.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int PostId { get; set; }
        public int SubdivisionId { get; set; }
        public Post Post { get; set; }
        public Subdivision Subdivision { get; set; }
    }
}
