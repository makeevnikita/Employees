using Employees.Context;
using Employees.Model;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Employees.View
{
    public partial class EmployeesPage : Page
    {
        private EmployeesContext _employeesContext;
        private Employee _selectedEmployee;
        public EmployeesPage()
        {
            InitializeComponent();
            _employeesContext = new EmployeesContext();

            _employeesContext.Posts.Load();
            _employeesContext.Subdivisions.Load();
            EmployeesViewModel.ItemsSource = _employeesContext.Employees.ToList();
            PostFilterComboBox.ItemsSource = _employeesContext.Posts.ToList();
            SubdivisionsFilterComboBox.ItemsSource = _employeesContext.Subdivisions.ToList();
        }
        private void EmployeesViewModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedEmployee = (Employee)EmployeesViewModel.SelectedItem;
            if (_selectedEmployee == null) return;
            EditButton.IsEnabled = true;
            DeleteButton.IsEnabled = true;
        }
        private void CreateEmployee(object sender, RoutedEventArgs e)
        {
            CreateEmployeeWindow createEmployeeWindow = new CreateEmployeeWindow();
            createEmployeeWindow.ShowDialog();
            FilterEmployees();
        }
        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            _employeesContext.Employees.Remove(_selectedEmployee);
            _employeesContext.SaveChanges();
            EmployeesViewModel.ItemsSource = _employeesContext.Employees.ToList();
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }
        private void EditEmployee(object sender, RoutedEventArgs e)
        {
            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(_selectedEmployee, _employeesContext);
            editEmployeeWindow.ShowDialog();
            FilterEmployees();
        }
        private void FilterEmployees()
        {
            Post selectedPost = PostFilterComboBox.SelectedItem as Post;
            Subdivision selectedSubdivision = SubdivisionsFilterComboBox.SelectedItem as Subdivision;

            if (selectedPost != null && selectedSubdivision != null)
            {
                EmployeesViewModel.ItemsSource = _employeesContext.Employees.Where(w => w.PostId == selectedPost.Id
                && w.SubdivisionId == selectedSubdivision.Id).ToList();
                return;
            }
            if (selectedPost != null)
            {
                EmployeesViewModel.ItemsSource = _employeesContext.Employees.Where(w => w.PostId == selectedPost.Id).ToList();
                return;
            }
            if (selectedSubdivision != null)
            {
                EmployeesViewModel.ItemsSource = _employeesContext.Employees.Where(w => w.SubdivisionId == selectedSubdivision.Id).ToList();
                return;
            }
        }
        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterEmployees();
        }

        private void ClearFilter(object sender, RoutedEventArgs e)
        {
            PostFilterComboBox.SelectedItem = null;
            SubdivisionsFilterComboBox.SelectedItem = null;
            EmployeesViewModel.ItemsSource = _employeesContext.Employees.ToList();
        }
    }
}
