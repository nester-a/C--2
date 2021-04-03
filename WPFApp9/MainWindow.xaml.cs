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

namespace WPFApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Employee> items = new List<Employee>();
            items.Add(new Employee() { Name = "Петя", Age = 42, Salary = 25000 });
            items.Add(new Employee() { Name = "Коля", Age = 39, Salary = 45000 });
            items.Add(new Employee() { Name = "Иван", Age = 7, Salary = 33000 });
            lvEmployee.ItemsSource = items;
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }

}
