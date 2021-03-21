using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork02
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker[] SimpleWorkers = new SimpleWorker[5];
            Worker[] Freelancers = new FreelanceWorker[5];

            for (int i = 0; i < 5; i++)
            {
                SimpleWorkers[i] = new SimpleWorker();
                Console.WriteLine(SimpleWorkers[i].ToString());
                Freelancers[i] = new FreelanceWorker();
                Console.WriteLine(Freelancers[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка массива по имени");
            ComparerByName comparatorByName = new ComparerByName();
            Array.Sort(SimpleWorkers, comparatorByName);
            for (int i = 0; i < SimpleWorkers.Length; i++)
            {
                Console.WriteLine(SimpleWorkers[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка массива по фамилии");
            ComparerBySurname comparatorBySurName = new ComparerBySurname();
            Array.Sort(SimpleWorkers, comparatorBySurName);
            for (int i = 0; i < SimpleWorkers.Length; i++)
            {
                Console.WriteLine(SimpleWorkers[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка массива по средней зп");
            ComparerBySalary comparatorBySalary = new ComparerBySalary();
            Array.Sort(SimpleWorkers, comparatorBySalary);
            for (int i = 0; i < SimpleWorkers.Length; i++)
            {
                Console.WriteLine(SimpleWorkers[i].ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Создаём класс внутри которого список Работников");
            Company mc = new Company(SimpleWorkers);
            mc.AddRange(Freelancers);

            Console.WriteLine();
            Console.WriteLine("Сортировка списка по имени");
            mc.SortByNames();
            foreach (var worker in mc)
            {
                Console.WriteLine(worker.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка списка по фамилии");
            mc.SortBySurnames();
            foreach (var worker in mc)
            {
                Console.WriteLine(worker.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Сортировка списка по средней зп");
            mc.SortBySalary();
            foreach (var worker in mc)
            {
                Console.WriteLine(worker.ToString());
            }

            Console.ReadKey();
        }
    }
}
