using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02
{
    class SimpleWorker : Worker
    {
        public double Salary { get; private set; }
        public SimpleWorker() : base()
        {
            Salary = GetRandomSalary();
        }
        public SimpleWorker(string name, string surname) : base(name, surname)
        {
            Salary = GetRandomSalary();
        }
        public SimpleWorker(string name, string surname, double salary) : base(name, surname)
        {
            Salary = salary;
        }
        public SimpleWorker(double salary) : base()
        {
            Salary = salary;
        }

        public override double CalcAverageSalary()
        {
            return Salary;
        }
        private double GetRandomSalary()
        {
            double result = rnd.Next(10000, 100000);
            return result;
        }
    }
}
