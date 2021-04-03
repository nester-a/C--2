using Company.Communication.CompanyService;
using System.Windows;

namespace Company
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }
        public Employee NewEmployee { get; set; }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
                //Если не инстанцироваться Работника в контроле, то сюда у нас поступает null
                NewEmployee = employeeControl.Employee;
                DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
