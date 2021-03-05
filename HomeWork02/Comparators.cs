using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02
{
    public class ComparerByName : IComparer
    {
        private int CompareByName(Worker x, Worker y)
        {
            if (x.Name[0] > y.Name[0]) return 1;
            else if (x.Name[0] == y.Name[0]) return 0;
            else return -1;
        }

        public int Compare(object x, object y)
        {
            return CompareByName((Worker)x, (Worker)y);
        }
    }
    public class ComparerBySurname : IComparer
    {
        private int CompareBySurname(Worker x, Worker y)
        {
            if (x.Surname[0] > y.Surname[0]) return 1;
            else if (x.Surname[0] == y.Surname[0]) return 0;
            else return -1;
        }

        public int Compare(object x, object y)
        {
            return CompareBySurname((Worker)x, (Worker)y);
        }
    }
    public class ComparerBySalary : IComparer
    {
        private int CompareBySalary(Worker x, Worker y)
        {
            if (x.CalcAverageSalary() > y.CalcAverageSalary()) return 1;
            else if (x.CalcAverageSalary() == y.CalcAverageSalary()) return 0;
            else return -1;
        }

        public int Compare(object x, object y)
        {
            return CompareBySalary((Worker)x, (Worker)y);
        }
    }
}
