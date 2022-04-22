using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgramEventDeletAfter5
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass(10);
            MyClass mc2 = new MyClass(5);

            Console.WriteLine($"age {mc.Age}");
            Console.WriteLine($"передаем по значению");
            SomeMethod0(mc);

            Console.WriteLine($"age {mc.Age}");
            Console.WriteLine($"передаем по ссылке");
            SomeMethod1(ref mc.Age);
  
            Console.WriteLine($"age {mc.Age}");


            Console.ReadKey();

        }

        public static void SomeMethod0(MyClass mc)
        {
            mc.Age += 5;

           
        }

        public static void SomeMethod1( ref int val)
        {
            val += 5;
        }



    }



    class MyClass
    {
         public int Age;

        public MyClass(int age)
        {
            this.Age = age;
        }
    }

}
