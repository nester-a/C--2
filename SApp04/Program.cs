using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp04
{
    
    class MyCustomException : Exception
    {
        public MyCustomException()
        {
            Console.WriteLine(base.Message);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12;
            
            //try
            //{

            //    throw new MyCustomException();
            //    // Блок операторов в которых может произойти исключени
            //    a = int.Parse(Console.ReadLine());
            //    Console.WriteLine($"Вы ввели число {a}");

            //    //throw new Exception("Неопределенная ошибка");
                
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("Неверный формат данных.");
            //}
            //catch (MyCustomException ex)
            //{
            //    Console.WriteLine($"Моя ошибка. Последнее значение переменной a = {a}");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine("Ошибка.");
            //}
            //finally
            //{
            //    //a1 = 122;
            //    Console.WriteLine("Завершение работы программы.");
            //}

            //Console.ReadKey();


            using (var stream2 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Test.txt", FileMode.Open, FileAccess.Write))
            {
                throw new Exception("Неопределенная ошибка");
                using (var streamWriter = new StreamWriter(stream2))
                {
                    streamWriter.WriteLine("Hello1");
                    streamWriter.WriteLine("Hello2");
                }
            }

            FileStream stream;
            try
            {
                stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Test.txt", FileMode.Open, FileAccess.Write);
                throw new Exception("Неопределенная ошибка");
            }
            finally
            {
                stream.Dispose();
            }

            Console.ReadKey();

        }
    }
}
