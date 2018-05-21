using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWhileProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass mc = new MyClass();

            while (mc.State)
            {
                Console.WriteLine($"{mc.State}");
                Console.WriteLine($"{mc.State}");
                Console.WriteLine($"{mc.State}");
                mc.State = false; // если строчку убрать то будте бесконечно выполняться 5 методов и выводить true
                Console.WriteLine($"{mc.State}"); // действия выполеняться при первом проходе 
                Console.WriteLine($"{mc.State}");// действия выполеняться при первом проходе
            }

            Console.ReadKey();
        }
    }
    public class MyClass
    {
        public bool State;
        public MyClass()
        {
            State = true;
        }
    }

   