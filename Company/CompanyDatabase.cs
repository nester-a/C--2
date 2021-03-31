using Company.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class CompanyDatabase
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=Company;User ID=CompanyRoot;Password=12345";

        public ObservableCollection<Employee> list { get; private set; }
        private static Random random = new Random();
        private const int CHAR_BOUND_L = 65;
        private const int CHAR_BOUND_H = 90;
        private static int employeeID = 1;

        public CompanyDatabase()
        {
            list = new ObservableCollection<Employee>();
            //AddEmployees(10);
            //SyncToDatabase();
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

        //для работы с СУБД
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();


                string sqlQuery = $@"INSERT INTO Employees (EmployeeId, Department, Name, Surname, Comment)
                                    VALUES ({employeeID},{(int)employee.Department},'{employee.Name}','{employee.Surname}','{employee.Comment}')";

                var command = new SqlCommand(sqlQuery, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    list.Add(employee);
                    employeeID++;
                }
                return res;
            }
        }
        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"DELETE FROM Employees WHERE EmployeeId = '{employee.Id}'";

                var command = new SqlCommand(sqlQuery, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    list.Remove(employee);
                }
                return res;
            }
        }

        public int Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"UPDATE Employees  SET
                                                    Department={(int)employee.Department},
                                                    Name='{employee.Name}',
                                                    Surname='{employee.Surname}',
                                                    Comment='{employee.Comment}'
                                                    WHERE EmployeeId='{employee.Id}'";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
            }
        }

        private void LoadFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"SELECT * FROM Employees";

                var command = new SqlCommand(sqlQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee()
                            {
                                Id = reader.GetInt32(0),
                                Department = (Department)reader.GetInt32(1),
                                Name = reader.GetValue(2).ToString(),
                                Surname = reader["Surname"].ToString(),
                                Comment = reader["Comment"].ToString()
                            };
                            employeeID = employee.Id;
                            list.Add(employee);
                        }
                        employeeID++;
                    }
                }
            }
        }

        public void SyncToDatabase()
        {
            foreach (var employee in list)
            {
                Add(employee);
            }
        }
    }
}
