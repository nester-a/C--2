using Phonebook.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace Phonebook
{
    public class PhonebookDatabase
    {
        public const string ConnectionString = "Data Source=localhost;Initial Catalog=Phonebook;User ID=PhonebookRoot;Password=12345";

        private static string[] PHONE_PREFIX = {"906", "495", "499"}; // Префексы телефонных номеров
        private static int CHAR_BOUND_L = 65; // Номер начального символа (для генерации последовательности символов)
        private static int CHAR_BOUND_H = 90; // Номер конечного  символа (для генерации последовательности символов)

        private Random random = new Random();
        public ObservableCollection<Contact> Contacts { get; set; }

        public PhonebookDatabase()
        {
            Contacts = new ObservableCollection<Contact>();
            //GenerateContacts(35);
            //SyncToDatabase();
            LoadFromDatabase();
        }

        //public void SyncToDatabase()
        //{
        //    foreach(var contact in Contacts)
        //    {
        //        Add(contact);
        //    }
        //}

        public int Add(Contact contact)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = contact.Locked ? 1 : 0;
                string sqlQuery = $@"INSERT INTO Contacts (Phone, LastName, FirstName, SecondName, Comment, Locked, CategoryId)
                                    VALUES ('{contact.Phone}','{contact.LastName}','{contact.FirstName}','{contact.SecondName}','{contact.Comment}',
                                    {locked}, {(int)contact.Category})";

                var command = new SqlCommand(sqlQuery, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Contacts.Add(contact);
                }
                return res;
            }
        }

        public int Remove(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var locked = contact.Locked ? 1 : 0;
                string sqlQuery = $@"DELETE FROM Contacts WHERE Phone = '{contact.Phone}'";

                var command = new SqlCommand(sqlQuery, connection);
                var res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    Contacts.Remove(contact);
                }
                return res;
            }
        }

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

        private void LoadFromDatabase()
        {
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
                            Contacts.Add(contact);
                        }
                    }
                }
            }
        }

        private string GenerateSymbols(int amount)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < amount; i++)
                stringBuilder.Append((char)(CHAR_BOUND_L + random.Next(CHAR_BOUND_H - CHAR_BOUND_L)));
            return stringBuilder.ToString();
        }

        private string GeneratePhone()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("+7").Append(PHONE_PREFIX[random.Next(3)]);
            for (int i = 0; i < 6; i++)
                stringBuilder.Append(random.Next(10));
            return stringBuilder.ToString();
        }

        private void GenerateContacts(int contactCount)
        {
            Contacts.Clear();

            string firstName = GenerateSymbols(random.Next(6) + 5);
            string lastName = GenerateSymbols(random.Next(6) + 5);
            string secondName = GenerateSymbols(random.Next(6) + 5);

            var locked = random.Next(0, 2) == 0 ? false : true;
            var category = (ContactCategory)random.Next(0, 3);

            for (int i = 0; i < contactCount; i++)
            {
                if (random.Next(2) == 0)
                {
                    firstName = GenerateSymbols(random.Next(6) + 5);
                    lastName = GenerateSymbols(random.Next(6) + 5);
                    secondName = GenerateSymbols(random.Next(6) + 5);
                    Debug.WriteLine(random.Next(0, 2));
                    locked = random.Next(0, 2) == 0 ? false : true;
                    category = (ContactCategory)random.Next(0, 3);

                }
                string phone = GeneratePhone();
                Contacts.Add(new Contact(phone, firstName, lastName, secondName, locked, category));
            }
        }

    }
}
