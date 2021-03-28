using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Employee : INotifyPropertyChanged, ICloneable
    {
        string _name;
        string _surname;
        Department _department;
        string _comment;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        public string Surname
        {
            get => _surname; 
            set
            {
                _surname = value;
                NotifyPropertyChanged();
            }
        }
        public Department Department
        {
            get => _department;
            set
            {
                _department = value;
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
        public string NameAndSurname { get => $"{Name} {Surname}"; }

        public Employee() { }
        public Employee(string name, string surname, Department department)
        {
            Name = name;
            Surname = surname;
            Department = department;
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
