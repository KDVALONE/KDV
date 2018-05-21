using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelleteAfter
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass1 a1 = new MyClass1();
            MyClass a = new MyClass();
            MyClass aa1 = new MyClass1();

            a.Print(1, 2, d:2);
            a1.Print();
            a1.Print(99, 99);


            Console.ReadKey();
        }
    }

    class MyClass
    {
        private int ax;
        private int bx;

        public int Ax { get; set; }
        public int Bx { get; set; }

        // тест конструкторов
        public MyClass(int ax)
            : this(int ax, 666)
        {

        }
        public MyClass()
        {

        }

        public void SomeCtorMethod() { Console.Write($"{Ax},{Bx}");} 

        public virtual void Print(int a, int b, int d = 4, int c = 3)
        {
            Console.WriteLine("MyClass {0}{1}{2}{3}", a, b, c, d);
        }
        public virtual void Print()
        {
            Console.WriteLine("MyClass Перегрузка");
        }

    }
    class MyClass1 : MyClass
    {

        public override void Print(int a, int b, int d = 0, int c = 0)
        {

            Console.WriteLine(" MyClass1 {0}{1}{2}{3}", a, b, c, d);
        }
        public new void Print()
        {
            Console.WriteLine("MyClass1 Перегрузка");
        }
    }

}
