using Phonebook.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace Phonebook.WebService
{
    /// <summary>
    /// Summary description for PhonebookService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PhonebookService : System.Web.Services.WebService
    {
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PhonebookConnectionString"].ConnectionString;

        
        [WebMethod]
        //public List<Contact> LoadFromDatabase()
        public List<Contact> Load()
        {
            //добавляем коллекцию
            List<Contact> contacts = new List<Contact>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = $@"SELECT * FROM Contacts";

                var command = new SqlCommand(sqlQuery, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var contact = new Contact()
                            {
                                Phone = reader.GetValue(0).ToString(),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader.GetString(2),
                                SecondName = reader["SecondName"].ToString(),
                                Comment = reader["Comment"].ToString(),
                                Locked = reader.GetBoolean(5),
                                Category = (ContactCategory)reader.GetInt32(6)
                            };
                            contacts.Add(contact);
                            //Contacts.Add(contact);
                        }
                    }
                    return contacts;
                }
            }
        }

        [WebMethod]
        public int Add(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = contact.Locked ? 1 : 0;
                string sqlQuery = $@"INSERT INTO Contacts (Phone, LastName, FirstName, SecondName, Comment, Locked, CategoryId)
                                    VALUES ('{contact.Phone}','{contact.LastName}','{contact.FirstName}','{contact.SecondName}','{contact.Comment}',
                                    {locked}, {(int)contact.Category})";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
                //var res = command.ExecuteNonQuery();
                //if (res > 0)
                //{
                //    Contacts.Add(contact);
                //}
                //return res;
            }
        }

        [WebMethod]
        public int Remove(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = contact.Locked ? 1 : 0;
                string sqlQuery = $@"DELETE FROM Contacts WHERE Phone = '{contact.Phone}'";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
                //var res = command.ExecuteNonQuery();
                //if (res > 0)
                //{
                //    Contacts.Remove(contact);
                //}
                //return res;
            }
        }

        [WebMethod]
        public int Update(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = contact.Locked ? 1 : 0;
                string sqlQuery = $@"UPDATE Contacts  SET
                                                    LastName='{contact.LastName}',
                                                    FirstName='{contact.FirstName}',
                                                    SecondName='{contact.SecondName}',
                                                    Comment='{contact.Comment}',
                                                    Locked={locked},
                                                    CategoryId={(int)contact.Category}
                                                    WHERE Phone = '{contact.Phone}'";

                var command = new SqlCommand(sqlQuery, connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
