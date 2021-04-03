using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Communication.CompanyService
{
    public partial class Employee
    {
        public string NameAndSurname { get => $"{Name} {Surname}"; }
        public Employee() { }
        public Employee(int id, string name, string surname, Department department)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Department = department;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
