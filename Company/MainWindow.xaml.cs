using Company.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal CompanyDatabase company = new CompanyDatabase();
        AddEmployeeChildWindow childWindow;
        public ObservableCollection<Employee> EmployeeList { get; set; }
        public Employee SelectedEmployee { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            EmployeeList = company.list;
            //Update();
            btnDelete.Click += btnDelete_Click;
        }

        private void Update()
        {
            companyListView.ItemsSource = null;
            companyListView.ItemsSource = company.list;
        }
        private void companyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                employeeControl.Employee = (Employee)SelectedEmployee.Clone();
                //employeeControl.SetEmployee(e.AddedItems[0] as Employee);
            }
        }
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (companyListView.SelectedItems.Count < 1)
            {
                return;
            }
            EmployeeList[EmployeeList.IndexOf(SelectedEmployee)] = employeeControl.Employee;
            //employeeControl.UpdateEmployee();
            Update();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (companyListView.SelectedItems.Count < 1)
            {
                return;
            }
            if (MessageBox.Show("Вы действительно желаете удалить данные сотрудника?", "Удаление данных сотрудника", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                company.list.Remove((Employee)companyListView.SelectedItems[0]);
                //employeeControl.SetEmployee(null);
                Update();
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            childWindow = new AddEmployeeChildWindow();
            childWindow.Show();
            childWindow.Owner = this;

            //
            // вот оно, то про что я говорил - событие подписывается на событие
            //
            childWindow.btnConfirm.Click += ChildWindow_btnConfirm_Click;
        }
        private void ChildWindow_btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (childWindow.isCorrect == true)
            {
                company.AddEmployee(childWindow.newEmployee);
                Update();
            }
        }
    }
}
