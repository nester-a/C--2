using Company.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class CompanyDatabase
    {
        public ObservableCollection<Employee> list { get; private set; }
        private static Random random = new Random();
        private const int CHAR_BOUND_L = 65;
        private const int CHAR_BOUND_H = 90;

        public CompanyDatabase()
        {
            list = new ObservableCollection<Employee>();
            AddEmployees(50);
        }
        public void AddEmployee(Employee employee)
        {
            list.Add(employee);
        }
        public void AddEmployee()
        {
            string name = GenerateSymbols(random.Next(4, 6));
            string surName = GenerateSymbols(random.Next(4, 9));
            Department department = GenerateDepartment();

            list.Add(new Employee(name, surName, department));
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
    }
}
