using Company.Communication.CompanyService;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

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
