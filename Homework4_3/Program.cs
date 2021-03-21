using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCodeOne();
            //см метод
            //MyCodeTwo();
            Console.ReadKey();

        }
        static void OriginalCode()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        static void MyCodeOne()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(n => n.Value);
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        static void MyCodeTwo()
        {
            //делегат для работы с KeyValuePair
            Func<KeyValuePair<string, int>, int> func = MyMethod;
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            //это мы будем передавть в делегат
            KeyValuePair<string, int> keyValuePair = new KeyValuePair<string, int>("four", dict["four"]);

            //перегрузка метода OrderBy принимает делегат Func<KeyValuePair<string, int>, int> который извлекает значение элемента.
            //Я сделал метод принимающий пару ключ-значение и возвращающий значение элемента
            //сделал делегат
            //объявил переменную типано вот как инстанцировать саму пару - непонятно
            //я так понял что словарь нельзя превести к данному типу
            // var d = dict.OrderBy(func(keyValuePair)); - это код не компилируется

            //********
            //как  Развернуть обращение к OrderBy с использованием делегата ?
            //********

            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
        //метод возвращающий значение из пары ключ-значение
        static int MyMethod(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
