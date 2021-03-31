using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    /// <summary>
    /// Контакт
    /// </summary>
    public class Contact : INotifyPropertyChanged, ICloneable
    {
        private string _phone;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _comment;
        private ContactCategory _category = ContactCategory.General;
        private bool _locked;


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { 
                _phone = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Блокировка
        /// </summary>
        public bool Locked
        {
            get { return _locked; }
            set
            {
                _locked = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Категория
        /// </summary>
        public ContactCategory Category
        {
            get { return _category; }
            set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }

        public string FIO
        {
            get { return $"{LastName} {FirstName} {LastName}"; }
        }

        #region Constructors

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

        

        #endregion

        public override string ToString()
        {
            return $"{Phone} - {LastName} {FirstName} {LastName}";
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
