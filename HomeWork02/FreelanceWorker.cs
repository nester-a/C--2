using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02
{
    class FreelanceWorker : Worker
    {
        public double OneHourPay { get; private set; }
        public FreelanceWorker() : base()
        {
            OneHourPay = GetRandomOneHourPay();
        }

        public FreelanceWorker(string name, string surname) : base(name, surname)
        {
            OneHourPay = GetRandomOneHourPay();
        }
        public FreelanceWorker(string name, string surname, double onehourpay) : base(name, surname)
        {
            OneHourPay = onehourpay;
        }
        public FreelanceWorker(double onehourpay) : base()
        {
            OneHourPay = onehourpay;
        }

        public override double CalcAverageSalary()
        {
            return 20.8 * 8 * OneHourPay;
        }
        private double GetRandomOneHourPay()
        {
            double result = rnd.Next(100, 1000);
            return result;
        }
    }
}
