using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            A b = new B();
            A c = new C();

            //c.Print();
            //c.PrintASecond();
            
            a.Print();
            
            b.Print();
            c.Print();

            //*************************************************

            //A Aa = new A();
            //B Bb = new B();
            //C Cc = new C();
            //Aa.Print();
            //Aa.PrintASecond();

            //Bb.Print(); // override A
            //Bb.PrintASecond();
            //Bb.PrintBSecond();

            //Cc.Print(); //(base)
            //Cc.PrintASecond();
            //Cc.PrintBSecond();
            //Cc.PrintCSecond();
            //*************************************************





            Console.ReadKey();


        }
    }
    class A
    {
        public virtual void Print()
        {
            Console.WriteLine("A::Рrint (base Method, public  void)");
        }
        public void PrintASecond()
        {
            Console.WriteLine("A::РrintASecond (second base Method, public void)");
        }


    }
    class B : A
    {
        public override void Print()
        {
            Console.WriteLine("B::Рrint (override)");
        }
        public void PrintBSecond()
        {
            Console.WriteLine("B::РrintBSecond (second base Method, public void)");
        }

    }
    class C : B
    {
        public new void Print()
        {
            base.Print();
            Console.WriteLine("C::Print");
        }
        public void PrintCSecond()
        {
            Console.WriteLine("C::РrintCSecond (second Method, public void)");
        }

    }

}


