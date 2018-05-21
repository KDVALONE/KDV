using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhileCycle
{
    class Program
    {
        static void Main(string[] args)
        {
            //В алгоритмах иногда требуется найти минимальную целую неотрицательную степень двойки, превосходящую данное число.
            //  Решите эту задачу с помощью цикла while.

            Console.WriteLine(GetMinPowerOfTwoLargerThan(2)); // => 4
            Console.WriteLine(GetMinPowerOfTwoLargerThan(15)); // => 16
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-2)); // => 1
            Console.WriteLine(GetMinPowerOfTwoLargerThan(-100));
            Console.WriteLine(GetMinPowerOfTwoLargerThan(100));
            Console.ReadKey();
        }
        


            private static int GetMinPowerOfTwoLargerThan(int number)
        {
            int i = 0;
            int st; ;
            while (true)
            {
                st = (Int32)Math.Pow(2, i);
                if (number < st && st > 0)
                { break; }
                else { i++; }
            }
            return st;
        }
        
    }
}
    
    

