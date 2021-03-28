using Company.Data;
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

namespace Company
{
    /// <summary>
    /// Interaction logic for AddEmployeeChildWindow.xaml
    /// </summary>
    public partial class AddEmployeeChildWindow : Window
    {
        internal Employee newEmployee;
        public bool isCorrect { get; set; }
        public AddEmployeeChildWindow()
        {
            InitializeComponent();
            newEmployee = new Employee();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            isCorrect = false;
            Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!employeeControl.isNotEmpty)
            {
                MessageBox.Show("Нужно заполнить все поля", "Ошибка заполнения полей", MessageBoxButton.OK);
                return;
            }
            isCorrect = true;
            newEmployee = employeeControl.Employee;
            //newEmployee = employeeControl.UpdateEmployee();
            Close();
        }
    }
}
