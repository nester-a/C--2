using Phonebook.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class PhoneDatabase
    {
        private static string[] PHONE_PREFIX = { "906", "495", "499" };
        private static int CHAR_BOUND_L = 65;
        private static int CHAR_BOUND_H = 90;
        private static Random random = new Random();
        public ObservableCollection<Contact> Contacts { get; set; }
        
        public PhoneDatabase()
        {
            Contacts = new ObservableCollection<Contact>();
            GenerateContacts(35);
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
        private string GeneratePhone()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("+7").Append(PHONE_PREFIX[random.Next(3)]);
            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(random.Next(10));
            }
            return stringBuilder.ToString();
        }

        private void GenerateContacts(int contactCount)
        {
            Contacts.Clear();

            string firstName = GenerateSymbols(random.Next(6) + 5);
            string lastName = GenerateSymbols(random.Next(6) + 5);
            string secondName = GenerateSymbols(random.Next(6) + 5);

            bool locked = random.Next(0, 2) == 0 ? false : true;
            var category = (ContactCategory)random.Next(0, 3);

            for (int i = 0; i < contactCount; i++)
            {
                if(random.Next(2) == 0)
                {
                    firstName = GenerateSymbols(random.Next(6) + 5);
                    lastName = GenerateSymbols(random.Next(6) + 5);
                    secondName = GenerateSymbols(random.Next(6) + 5);

                    locked = random.Next(0, 2) == 0 ? false : true;
                    category = (ContactCategory)random.Next(0, 3);
                }
                string phone = GeneratePhone();

                Contacts.Add(new Contact(phone, firstName, lastName, secondName, locked, category));
            }
        }
    }
}
