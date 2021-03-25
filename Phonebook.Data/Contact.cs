using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class Contact
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Comment { get; set; }
        public bool Locked { get; set; }
        public ContactCategory Category { get; set; } = ContactCategory.General;

        public string FIO
        {
            get
            {
                return $"{LastName} {FirstName} {SecondName}";
            }
        }
        public Contact() { }
        public Contact(string phone, string firstName, string lastName, string secondName, bool locked, ContactCategory category)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
            Locked = locked;
            Category = category;
        }
    }
}
