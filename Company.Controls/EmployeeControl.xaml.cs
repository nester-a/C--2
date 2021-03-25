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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Company.Controls
{
    /// <summary>
    /// Interaction logic for EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        private Employee employee;
        public bool isNotEmpty
        {
            get
            {
                if(txtbName.Text == null || txtbSurname.Text == null ||chbDepartment.SelectedValue == default)
                {
                    return false;
                }
                return true;
            }
        }
        public EmployeeControl()
        {
            InitializeComponent();
            chbDepartment.ItemsSource = Enum.GetValues(typeof(Department)).Cast<Department>();
        }
        public void SetEmployee(Employee employee)
        {
            if(employee == null)
            {
                txtbName.Text = null;
                txtbSurname.Text = null;
                txtbComment.Text = null;
                chbDepartment.SelectedItem = null;
            }
            else
            {
                this.employee = employee;
                txtbName.Text = employee.Name;
                txtbSurname.Text = employee.Surname;
                txtbComment.Text = employee.Comment;
                chbDepartment.SelectedItem = employee.Department;
            }
        }
        public Employee UpdateEmployee()
        {
            if(employee == null)
            {
                employee = new Employee();
            }
            employee.Name = txtbName.Text;
            employee.Surname = txtbSurname.Text;
            employee.Department = (Department)chbDepartment.SelectedItem;
            employee.Comment = txtbComment.Text;

            return employee;
        }
    }
}
