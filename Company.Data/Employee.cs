using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
        //public string DepartmentString
        //{
        //    get
        //    {
        //        if (this.Department == Department.Sales)
        //            return "Sales";
        //        else if (this.Department == Department.Purchasing)
        //            return "Purchasing";
        //        else
        //            return "Service";
        //    }
        //}

        public string Comment { get; set; }
        public string NameAndSurname { get => $"{Name} {Surname}"; }

        public Employee()
        {

        }
        public Employee(string name, string surname, Department department)
        {
            Name = name;
            Surname = surname;
            Department = department;
        }
    }
}
