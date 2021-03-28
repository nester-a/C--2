using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp01
{
    
    public enum Gender
    {
        Male,
        Famale
    }

    public struct Sample
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public object Gender { get; set; }
    }

    public class PersonV2<TGender, TAge>
    {
        public string Name { get; set; }
        public TAge Age { get; set; }
        public TGender Gender { get; set; }

        public PersonV2(string name, TAge age, TGender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

    }

    public class PersonV3<TGender> where TGender : new()
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TGender Gender { get; set; }

        public PersonV3(string name, int age, TGender gender)
        {       
            Name = name;
            Age = age;
            Gender = gender;
        }
    }

    public class PersonV4<TGender, TAge> : PersonV2<TGender, TAge>
    {
        public PersonV4(string name, TAge age, TGender gender) : base (name, age, gender)
        {
  
        }
    }

    public class PersonV5 : PersonV2<Gender, int> 
    {
        public PersonV5(string name, int age, Gender gender) : base(name, age, gender)
        {

        }
    }



    class Program
    {

        static void Swap(ref int a, ref int b)
        {
            int c;
            c = a;
            a = b;
            b = c;
        }

        static void Swap<T>(ref T a, ref T b/*, int d, string f*/)
        {
            T c;
            c = a;
            a = b;
            b = c;
        }
        
        static void Main(string[] args)
        {
            int a = 12;
            int b = -1;
            decimal a1 = 1;
            decimal b1 = -6;

            Swap(ref a, ref b);
            Swap<decimal>(ref a1, ref b1);

            var person01 = new Person() { Name = "Андрей", Age = 22, Gender = "Мужчина" };
            //var person12 = new PersonV2<Gender, int>();
            var person02 = new PersonV2<Gender, int>("Андрей", 22, Gender.Male);
            var person03 = new PersonV2<object, int>("Андрей", 22, "Мужчина");
            var person04 = new PersonV3<Gender>("Андрей", 22, Gender.Male);
        }
    }
}
