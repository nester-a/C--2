using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Communication.PhonebookService
{
    public partial class Contact : ICloneable
    {
        public Contact() { }

        public Contact(string phone, string firstName, string lastName, string secondName)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;
        }

        public Contact(string phone, string firstName, string lastName, string secondName, bool locked, ContactCategory category)
        {
            Phone = phone;
            FirstName = firstName;
            LastName = lastName;
            SecondName = secondName;

            Locked = locked;
            Category = category;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
