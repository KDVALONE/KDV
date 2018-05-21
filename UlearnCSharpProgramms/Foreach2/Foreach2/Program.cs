using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach2
{
    class Program
    {

        //А вам выпала задача посложнее — написать метод поиска индекса максимального элемента. То есть такого числа i, что array[i] — это максимальное из чисел в массиве.

        //Если в массиве максимальный элемент встречается несколько раз, вывести нужно минимальный индекс.

        //Если массив пуст, вывести нужно -1.

        //	2 -1 0 1 3 0

        static void Main(string[] args)
        {
            Console.WriteLine(MaxIndex(new double[] { 1, 2, 3 }));//	2
            Console.WriteLine(MaxIndex(new double[] { }));//	-1
            Console.WriteLine(MaxIndex(new double[] { 1 }));//	0
            Console.WriteLine(MaxIndex(new double[] { 0, 100, 1, 2, 100 }));//	1
            Console.WriteLine(MaxIndex(new double[] { 1, 2, 3, 100, 4, 5, 6 }));//	3
            Console.WriteLine(MaxIndex(new double[] { 100, 100, 100, 100 }));//	0
            Console.ReadKey();
        }
        public static int MaxIndex(double[] array)
        {
            var min = double.MinValue;
            int buf = 0;
            int i = 0;
            if (array.Length < 1)
                return -1;
            else
            foreach (var item in array)
                if (item > min)
                {
                        i++; min = item; buf = i-1; 
                }
                else if (item == min)
                {   
                    i++;
                }
                else
                {
                    i++;
                }
            return buf;
        }
    }
}
