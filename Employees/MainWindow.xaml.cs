using Employees.Context;
using Employees.Model;
using Employees.View;
using System.Collections.Generic;
using System.Linq;
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

            using (EmployeesContext employeesContext = new EmployeesContext())
            {
                if (employeesContext.Posts.Count() == 0)
                {
                    List<Post> posts = new List<Post>()
                    { new Post { Id = 1, PostName = "Директор"},
                    new Post { Id = 2, PostName = "Руководитель"},
                    new Post { Id = 3, PostName = "Контролёр"},
                    new Post { Id = 4, PostName = "Работник"},};
                    employeesContext.Posts.AddRange(posts);
                    employeesContext.SaveChanges();
                }
            }
        }
    }
}
