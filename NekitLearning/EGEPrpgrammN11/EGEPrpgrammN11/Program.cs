using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGEPrpgrammN11
{
    class Program
    {
        public static int n = 2;
        static void Main(string[] args)
        {
            ClassForMethod.F(n);

            Console.ReadKey();

        }

       

    }

    public static class ClassForMethod
    {

        public static void F(int n) // функция F, принимающая на вход n
        {
            Console.WriteLine($"{n}"); // вывести на эран текущее значение n  при запуске функции F

                               
            if (n < 7)
            {
                F(n + 2);
                F(n + 3);
            }

        }
    }



}
