using Company.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class EmployeeControl : UserControl, INotifyPropertyChanged
    {
        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Department> DepartmentList { get; set; } = new ObservableCollection<Department>();
                
        public EmployeeControl()
        {
            InitializeComponent();

            //инициализурую Работника, поскольку без него при добавлении нового работника в переменную нового работника присваивается null
            Employee = new Employee();

            this.DataContext = this;

            DepartmentList.Add(Department.Purchasing);
            DepartmentList.Add(Department.Sales);
            DepartmentList.Add(Department.Service);

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool isNotEmpty
        {
            get
            {
                if (txtbName.Text == null || txtbSurname.Text == null || chbDepartment.SelectedValue == default)
                {
                    return false;
                }
                return true;
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
