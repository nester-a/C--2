using Company.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Company.WebService
{
    /// <summary>
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CompanyService : System.Web.Services.WebService
    {
        private static int employeeID = 1;
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CompanyConnectionString"].ConnectionString;

        [WebMethod]
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();


                string sqlQuery = $@"INSERT INTO Employees (EmployeeId, Department, Name, Surname, Comment)
                                    VALUES ({employeeID},{(int)employee.Department},'{employee.Name}','{employee.Surname}','{employee.Comment}')";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public int Remove(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"DELETE FROM Employees WHERE EmployeeId = '{employee.Id}'";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
            }
        }

        [WebMethod]
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

        [WebMethod]
        public List<Employee> Load()
        {
            List<Employee> employees = new List<Employee>();
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
                            employees.Add(employee);
                        }
                        employeeID++;
                    }
                    return employees;
                }
            }
        }
    }
}
