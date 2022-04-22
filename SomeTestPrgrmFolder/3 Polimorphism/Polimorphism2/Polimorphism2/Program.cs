using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorphism2
{
    class Program
    {
        int x = 1;
        static void Main(string[] args)
        {
            // Класс чисто для потрениться на upcast и downcast
            A a1 = new A();
            A b1 = new C(); // тут нужно предстваить обьект С как обьект А 
            C c1 = new C1();

            
            Console.ReadKey();
        }
    }
    public class A
    {
       virtual public void M1()
        {
            Console.WriteLine("A::M1");
        }
        public virtual void M2()
        {
            Console.WriteLine("A::M2");
        }
        public void M3()
        {
            Console.WriteLine("A::M3");
        }
    }
    public class B : A
    {
        //override public void M2()
        //{
        //    Console.WriteLine("B:A::M2");
        //}
        public void M3()
        {
            base.M3();
            Console.WriteLine("B:A::M3");

        }

    }

    public class C : B
    {
 
        override public void M2()
        {
            Console.WriteLine("C:B::M2");
        }
        public void M4()
        {
            Console.WriteLine("C:B::M4");
        }
        public void M3()
        {
            Console.WriteLine("C:B::M3");
        }
    }
    public class D : A
    {
        override public void M2()
        {
            Console.WriteLine("D:A::M1");
        }
    }
    public class C1 : C
    {
        new public void M2()
        {
            base.M3();
            Console.WriteLine("C1:C::M2");
        }
    }
} 