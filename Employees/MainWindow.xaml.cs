using Employees.View;
using System.Windows;

namespace Employees
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Helper.MainFrame = MainWindowFrame;
            Helper.MainFrame.Navigate(new EmployeesPage());
        }
    }
}
