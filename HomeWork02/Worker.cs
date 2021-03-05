using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace HomeWork02
{
    //1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой (один из потомков) и фиксированной оплатой (второй потомок).
    //а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
    //Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», 
    //для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
    //б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
    //в) * Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
    //г) * Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
    public abstract class Worker
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        #region Листы различных имён и фамилий
        private List<string> RandomName;
        private List<string> RandomSurname;
        protected static Random rnd = new Random();
        #endregion
        protected Worker()
        {
            InitNamesAndSurnames();
            Name = RandomName[rnd.Next(0, 4)];
            Surname = RandomSurname[rnd.Next(0, 4)];
        }
        protected Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
        public abstract double CalcAverageSalary();
        private void InitNamesAndSurnames()
        {
            RandomName = new List<string>() { "Иван", "Пётр", "Фёдор", "Алексей" };
            RandomSurname = new List<string>() { "Иванов", "Петров", "Фёдоров", "Алексеев" };
        }
        public override string ToString()
        {
            return $"Работник {Surname} {Name}. Средняя зарплата {CalcAverageSalary()}";
        }
    }
}
