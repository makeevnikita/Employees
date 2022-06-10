using Employees.Context;
using Employees.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Employees.View
{
    public partial class CreateEmployeeWindow : Window
    {
        private EmployeesContext _employeesContext;
        private EmployeeValidation _employeeValidation;
        public CreateEmployeeWindow()
        {
            InitializeComponent();
            _employeesContext = new EmployeesContext();
            SubdivisionsComboBox.ItemsSource = _employeesContext.Subdivisions.ToList();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Surname = SurnameTextBox.Text;
            employee.Name = NameTextBox.Text;
            employee.Patronymic = PatronymicTextBox.Text;
            employee.Subdivision = (Subdivision)SubdivisionsComboBox.SelectedItem;
            employee.PostId = 4;

            _employeeValidation = new EmployeeValidation();
            if (!_employeeValidation.Validate(employee).IsValid) return;

            _employeesContext.Employees.Add(employee);
            _employeesContext.SaveChanges();
            Close();
        }
    }
}
