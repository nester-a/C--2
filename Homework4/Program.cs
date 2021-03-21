using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, -2, 3, -4, 3, -8, -8, 8 };
            Count(numbers);
            Console.WriteLine("***");

            ArrayList list = new ArrayList();
            list.Add("привет");
            list.Add(1);
            list.Add('q');
            list.Add(1);
            list.Add("привет");
            Count(list);
            Console.WriteLine("***");

            CountWithLinq<int>(numbers);
            Console.ReadKey();
        }
        private static void Count(List<int> list)
        {
            int[] counter = new int[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        counter[i]++;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Элемент {list[i]} встречается в коллекции {counter[i]} раз");
            }
        }
        private static void Count(ArrayList list)
        {
            int[] counter = new int[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i].Equals(list[j]))
                    {
                        counter[i]++;
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Элемент {list[i]} встречается в коллекции {counter[i]} раз");
            }
        }
        private static void CountWithLinq<T>(List<T> list)
        {
            int[] counter = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                var tmp = from n
                          in list
                          where n.Equals(list[i])
                          select n;
                counter[i] = tmp.Count();
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"Элемент {list[i]} встречается в коллекции {counter[i]} раз");
            }
        }
    }
}
