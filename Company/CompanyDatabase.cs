using Company.Communication.CompanyService;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace Company
{
    class CompanyDatabase
    {
        CompanyServiceSoapClient companyServiceSoapClient = new CompanyServiceSoapClient();

        public ObservableCollection<Employee> list { get; private set; }
        private static Random random = new Random();
        private const int CHAR_BOUND_L = 65;
        private const int CHAR_BOUND_H = 90;
        private static int employeeID = 1;

        public CompanyDatabase()
        {
            list = new ObservableCollection<Employee>();
            LoadFromDatabase();
        }
        public void AddEmployee()
        {
            string name = GenerateSymbols(random.Next(4, 6));
            string surName = GenerateSymbols(random.Next(4, 9));
            Department department = GenerateDepartment();

            list.Add(new Employee(employeeID, name, surName, department));
            employeeID++;
        }
        private string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < amount; i++)
            {
                stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
            }
            return stringBuilder.ToString();
        }
        private Department GenerateDepartment()
        {
            int tmp = random.Next(0, 3);
            return (Department)tmp;
        }
        private void AddEmployees(int amount)
        {
            list.Clear();
            for (int i = 0; i < amount; i++)
            {
                AddEmployee();
            }
        }


        public int Add(Employee employee)
        {
            var res = companyServiceSoapClient.Add(employee);
            if (res > 0)
            {
                list.Add(employee);
                employeeID++;
            }
            return res;
        }
        public int Remove(Employee employee)
        {
            var res = companyServiceSoapClient.Remove(employee);
            if (res > 0)
            {
                list.Remove(employee);
            }
            return res;
        }

        public int Update(Employee employee)
        {
            return companyServiceSoapClient.Update(employee);
        }

        private void LoadFromDatabase()
        {
            foreach (var employee in companyServiceSoapClient.Load())
            {
                list.Add(employee);
            }
        }
    }
}
