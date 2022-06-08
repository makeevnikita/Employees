using Employees.Model;
using Employees.Repos;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private EmployeeRepo _employeeRepo;
        private PostRepo _postRepo;
        public EmployeesPage()
        {
            InitializeComponent();
            _employeeRepo = new EmployeeRepo();
            _postRepo = new PostRepo();

            EmployeesViewModel.ItemsSource = _employeeRepo.GetAllEmployees().ToList();
            PostsComboBox.ItemsSource = _postRepo.GetAllPosts().ToList();
        }

        private void EmployeesViewModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee employee = (Employee)EmployeesViewModel.SelectedItem;
            MessageBox.Show(employee.Surname + " " + employee.Post.PostName + " " + employee.Id);
            SurnameTextBox.Text = employee.Surname;
            NameTextBox.Text = employee.Name;
            PatronymicTextBox.Text = employee.Patronymic;
            PostsComboBox.SelectedItem = _postRepo.GetPostById(employee.Post.Id);
        }

        private void CreateEmployee(object sender, RoutedEventArgs e)
        {
            _employeeRepo.CreateEmployee(
                SurnameTextBox.Text,
                NameTextBox.Text,
                PatronymicTextBox.Text,
                (Post)PostsComboBox.SelectedItem);

        }
    }
}
