using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class Contact : INotifyPropertyChanged, ICloneable
    {
        private string _phone;
        private string _firstName;
        private string _lastName;
        private string _secondName;
        private string _comment;
        private bool _locked;
        private ContactCategory _category = ContactCategory.General;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                NotifyPropertyChanged();
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                NotifyPropertyChanged();
            }
        }
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
                NotifyPropertyChanged();
            }
        }
        public bool Locked
        {
            get => _locked;
            set
            {
                _locked = value;
                NotifyPropertyChanged();
            }
        }
        public ContactCategory Category
        {
            get => _category;
            set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }
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
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
