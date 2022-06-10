using Employees.Context;
using Employees.Model;
using System.Linq;
using System.Windows;

namespace Employees.View
{
    public partial class EditEmployeeWindow : Window
    {
        private EmployeesContext _employeesContext;
        private Employee _selectedEmployee;
        private EmployeeValidation _employeeValidation;
        public EditEmployeeWindow(Employee employee, EmployeesContext employeesContext)
        {
            InitializeComponent();
            _employeesContext = employeesContext;
            _selectedEmployee = employee;
            SubdivisionsComboBox.ItemsSource = _employeesContext.Subdivisions.ToList();

            SurnameTextBox.Text = _selectedEmployee.Surname;
            NameTextBox.Text = _selectedEmployee.Name;
            PatronymicTextBox.Text = _selectedEmployee.Patronymic;
            PostTextBox.Text = "Должность: " + _selectedEmployee.Post.PostName;
            SubdivisionsComboBox.SelectedItem = _selectedEmployee.Subdivision;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            Subdivision selectedSubdivision = (Subdivision)SubdivisionsComboBox.SelectedItem;

            _selectedEmployee.Surname = SurnameTextBox.Text;
            _selectedEmployee.Name = NameTextBox.Text;
            _selectedEmployee.Patronymic = PatronymicTextBox.Text;
            _selectedEmployee.SubdivisionId = selectedSubdivision.Id;

            _employeeValidation = new EmployeeValidation();
            if (!_employeeValidation.Validate(_selectedEmployee).IsValid) return;
            _employeesContext.SaveChanges();

            Close();
        }
        private void Upgrade(object sender, RoutedEventArgs e)
        {
            switch (_selectedEmployee.PostId)
            {
                case 4:
                    _selectedEmployee.PostId = 3;
                    PostTextBox.Text = "Должность: контролёр";
                    break;
                case 3:
                    _selectedEmployee.PostId = 2;
                    PostTextBox.Text = "Должность: руководитель";
                    break;
                case 2:
                    _selectedEmployee.PostId = 1;
                    PostTextBox.Text = "Должность: директор";
                    break;
            }
        }
        private void Downgrade(object sender, RoutedEventArgs e)
        {
            switch (_selectedEmployee.PostId)
            {
                case 1:
                    _selectedEmployee.PostId = 2;
                    PostTextBox.Text = "Должность: руководитель";
                    break;
                case 2:
                    _selectedEmployee.PostId = 3;
                    PostTextBox.Text = "Должность: котролёр";
                    break;
                case 3:
                    _selectedEmployee.PostId = 4;
                    PostTextBox.Text = "Должность: работник";
                    break;
            }
        }
    }
}
