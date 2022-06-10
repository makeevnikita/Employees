using Employees.Model;
using FluentValidation;
using System.Linq;

namespace Employees
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Surname).NotEmpty().Must(x => x.All(char.IsLetter));
            RuleFor(x => x.Name).NotEmpty().Must(x => x.All(char.IsLetter));
            RuleFor(x => x.Patronymic).NotEmpty().Must(x => x.All(char.IsLetter));
            RuleFor(x => x.SubdivisionId).NotEmpty();
        }
    }
}
